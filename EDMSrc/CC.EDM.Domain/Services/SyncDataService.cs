using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CC.EDM.Model.RealEDMDb;
using EDMWebsite.Models.ViewModels;
using Newtonsoft.Json;
using EDMWebsite;
using EDMWebsite.Models.DbModels;
using EDMWebsite.Models;
using CC.Product.Core.Extensions;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace CC.EDM.Domain.Services
{
    public interface ISyncDataService
    {
        void SyncEnergyItemData();
        void SyncEnergyHourData();
        void SyncEnergyDayData();
        void SyncEnergyMonthData();
    }
    public class SyncDataService : ISyncDataService
    {
        public DeviceDbContext MysqlDb { get; set; }
        public WriteableSqlDbContext NewEdmDb { get; set; }

        private List<RoomHosts> _roomHostsCache;
        public List<RoomHosts> RoomHostsCache
        {
            get
            {
                if (_roomHostsCache == null)
                {
                    _roomHostsCache = NewEdmDb.RoomHosts.ToList();
                }
                return _roomHostsCache;
            }
        }

        private List<EnergyPorts> _energyPortsCache;
        public List<EnergyPorts> EnergyPortsCache
        {
            get
            {
                if (_energyPortsCache == null)
                {
                    _energyPortsCache = NewEdmDb.EnergyPorts.ToList();
                }
                return _energyPortsCache;
            }
        }
        private string _syncComdictType = "SyncData";
        private string _lastSyncComdictKeyForEnergyItem = "LastSyncDateTimeForEnergyItem";
        private string _lastSyncComdictKeyForHour = "LastSyncDateTimeForEnergyHour";
        private string _lastSyncComdictKeyForDay = "LastSyncDateTimeForEnergyDay";
        private string _lastSyncComdictKeyForMonth = "LastSyncDateTimeForEnergyMonth";

        private string _lastLastSyncComdictKeyForEnergyItem = "LastLastSyncDateTimeForEnergyItem";
        private string _lastLastSyncComdictKeyForHour = "LastLastSyncDateTimeForEnergyHour";
        private string _lastLastSyncComdictKeyForDay = "LastLastSyncDateTimeForEnergyDay";
        private string _lastLastSyncComdictKeyForMonth = "LastLastSyncDateTimeForEnergyMonth";


        public SyncDataService()
        {
            MysqlDb = new DeviceDbContext();
            NewEdmDb = new WriteableSqlDbContext();
            NewEdmDb.Database.Log = s => CC.Product.Core.LogHelper.WriteInfo(s);
            MysqlDb.Database.Log = s => CC.Product.Core.LogHelper.WriteInfo(s);
            this.MysqlDb.Database.CommandTimeout = 30000;
        }

        public void SyncEnergyItemData()
        {
            DateTime SyncDateTime = DateTime.Now;
            var lastedDateTime = GetSyncDateTime(_lastSyncComdictKeyForEnergyItem);

            var processCount = 10000;
            var index = 0;
            var hasNext = true;
            List<EnergyItemResult> NewData = new List<EnergyItemResult>();
            while (hasNext)
            {
                var sql = "select a.id id,a.macip macip,a.port port,"
            + " value-(select ifnull(max(b.value),a.value)  from tb_data b where b.id < a.id and a.macip=b.macip and a.port = b.port) as value"
            + " ,a.time from tb_data a"
            + " where time>=STR_TO_DATE('{0}', '%Y%m%d%H%i%s') and time <STR_TO_DATE('{1}', '%Y%m%d%H%i%s')"
            + " order by id limit {2},{3}";

                sql = string.Format(sql, lastedDateTime.ToStringWithFullTime(), SyncDateTime.ToStringWithFullTime(), index, processCount);

                var syncOriginalList = MysqlDb.Database.SqlQuery<tb_data>(sql).ToList();


                //var syncOriginalList = MysqlDb.tb_data
                //    .Where(s => s.time >= lastedData && s.time < SyncDateTime)
                //    .OrderBy(s => s.id)
                //    .Skip(index).Take(processCount).ToList();

                index = index + processCount;
                //hasNext = false;
                if (syncOriginalList.Count == 0)
                {
                    hasNext = false;
                }
                else
                {
                    foreach (var item in syncOriginalList)
                    {
                        //host是唯一的，因为一个控制器对应一个host 所以必须唯一。这里增加RoomHosts的时候要做唯一处理
                        var roomHost = RoomHostsCache.SingleOrDefault(s => s.Hosts == item.macip && s.Port == item.port);
                        if (roomHost != null)
                        {
                            //要是一个控制器对应多个房间的时候，这里只给第一个房间赋值上value
                            var room = roomHost.Rooms.FirstOrDefault();
                            var energyTypeItem = roomHost.EnergyType;
                            if (room != null && energyTypeItem != null)
                            {
                                EnergyItemResult energyItem = GenerateEnergyItem(item, room, energyTypeItem);
                                if (energyItem != null)
                                {
                                    NewData.Add(energyItem);
                                }
                            }
                        }
                    }

                    using (var dbContextTransaction = NewEdmDb.Database.BeginTransaction())
                    {
                        try
                        {
                            NewEdmDb.EnergyItemResults.AddRange(NewData);
                            NewEdmDb.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();

                            //写log 记录哪些同步失败
                            LogSyncErrorData(SyncDateTime, syncOriginalList, ex);

                        }
                    }

                }
            }
            SaveSyncDateTime(lastedDateTime,_lastLastSyncComdictKeyForEnergyItem);

            SaveSyncDateTime(SyncDateTime, _lastSyncComdictKeyForEnergyItem);

        }

        public void SyncEnergyHourData()
        {
            var lastSyncDateTime = GetSyncDateTime(_lastSyncComdictKeyForHour);
            var SyncDateTime = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,DateTime.Now.Hour,0,0) ;

            var data = from a in NewEdmDb.EnergyItemResults
                       where a.StartDate >= lastSyncDateTime && a.StartDate < SyncDateTime
                       group a by new
                       {
                           a.StartDate.Year,
                           a.StartDate.Month,
                           a.StartDate.Day,
                           a.StartDate.Hour,
                           a.Room,
                           a.EnergyType
                       } into g
                       select new
                       {
                           hourSum = g.Sum(a => a.EnergyValue),
                           year = g.Key.Year,
                           month = g.Key.Month,
                           day = g.Key.Day,
                           hour = g.Key.Hour,
                           room = g.Key.Room,
                           energyType = g.Key.EnergyType
                       };
            var cc = data.ToList();

            List<EnergyItemHourResult> SyncList = new List<EnergyItemHourResult>();
            foreach (var item in cc)
            {
                var energyHourItem = new EnergyItemHourResult();
                energyHourItem.StartDate = new DateTime(item.year, item.month, item.day, item.hour, 0, 0);
                energyHourItem.EndDate = energyHourItem.StartDate;
                energyHourItem.EnergyValue = item.hourSum;
                energyHourItem.EnergyType = item.energyType;
                energyHourItem.Room = item.room;
                SyncList.Add(energyHourItem);
            }
            NewEdmDb.EnergyItemHourResults.AddRange(SyncList);
            NewEdmDb.SaveChanges();

            SaveSyncDateTime(lastSyncDateTime, _lastLastSyncComdictKeyForHour);
            SaveSyncDateTime(SyncDateTime,_lastSyncComdictKeyForHour);
        }

        public void SyncEnergyDayData()
        {
            var lastSyncDateTime = GetSyncDateTime(_lastSyncComdictKeyForDay);
            var SyncDateTime = DateTime.Now.Date;

            var data = from a in NewEdmDb.EnergyItemHourResults
                       where a.StartDate >= lastSyncDateTime && a.StartDate < SyncDateTime
                       group a by new
                       {
                           a.StartDate.Year,
                           a.StartDate.Month,
                           a.StartDate.Day,
                           a.Room,
                           a.EnergyType
                       } into g
                       select new
                       {
                           hourSum = g.Sum(a => a.EnergyValue),
                           year = g.Key.Year,
                           month = g.Key.Month,
                           day = g.Key.Day,
                           room = g.Key.Room,
                           energyType = g.Key.EnergyType
                       };
            var cc = data.ToList();

            List<EnergyItemDayResult> SyncList = new List<EnergyItemDayResult>();
            foreach (var item in cc)
            {
                var energyDayItem = new EnergyItemDayResult();
                energyDayItem.StartDate = new DateTime(item.year, item.month, item.day, 0, 0, 0);
                energyDayItem.EndDate = energyDayItem.StartDate;
                energyDayItem.EnergyValue = item.hourSum;
                energyDayItem.EnergyType = item.energyType;
                energyDayItem.Room = item.room;
                SyncList.Add(energyDayItem);
            }
            NewEdmDb.EnergyItemDayResults.AddRange(SyncList);
            NewEdmDb.SaveChanges();

            SaveSyncDateTime(lastSyncDateTime, _lastLastSyncComdictKeyForDay);
            SaveSyncDateTime(SyncDateTime,_lastSyncComdictKeyForDay);
        }

        public void SyncEnergyMonthData()
        {
            var lastSyncDateTime = GetSyncDateTime(_lastSyncComdictKeyForMonth);
            var SyncDateTime = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1,0,0,0);

            var data = from a in NewEdmDb.EnergyItemDayResults
                       where a.StartDate >= lastSyncDateTime && a.StartDate < SyncDateTime
                       group a by new
                       {
                           a.StartDate.Year,
                           a.StartDate.Month,
                           a.Room,
                           a.EnergyType
                       } into g
                       select new
                       {
                           hourSum = g.Sum(a => a.EnergyValue),
                           year = g.Key.Year,
                           month = g.Key.Month,
                           room = g.Key.Room,
                           energyType = g.Key.EnergyType
                       };
            var cc = data.ToList();

            List<EnergyItemMonthResult> SyncList = new List<EnergyItemMonthResult>();
            foreach (var item in cc)
            {
                var energyMonthItem = new EnergyItemMonthResult();
                energyMonthItem.StartDate = new DateTime(item.year, item.month, 1, 0, 0, 0);
                energyMonthItem.EndDate = energyMonthItem.StartDate;
                energyMonthItem.EnergyValue = item.hourSum;
                energyMonthItem.EnergyType = item.energyType;
                energyMonthItem.Room = item.room;
                SyncList.Add(energyMonthItem);
            }
            NewEdmDb.EnergyItemMonthResult.AddRange(SyncList);
            NewEdmDb.SaveChanges();

            SaveSyncDateTime(lastSyncDateTime, _lastLastSyncComdictKeyForMonth);
            SaveSyncDateTime(SyncDateTime,_lastSyncComdictKeyForMonth);

        }

        public void ClearSyncData()
        {
            
        }

        #region Helpers
        private DateTime GetSyncDateTime(string key)
        {
            var lastedDataModel = NewEdmDb.Comdicts.SingleOrDefault(s => s.Type == _syncComdictType && s.Key == key);
            DateTime lastedDateTime = new DateTime(2010, 10, 10);
            if (lastedDataModel != null)
                lastedDateTime = lastedDataModel.Value.ToDateTimeWithFullTime();
            return lastedDateTime;
        }


        private EnergyItemResult GenerateEnergyItem(tb_data item, Room room, EnergyType energyTypeItem)
        {
            EnergyItemResult energyItem = new EnergyItemResult();
            energyItem.StartDate = item.time;
            energyItem.EndDate = item.time;
            energyItem.EnergyDeviceCode = item.id.ToString();
            energyItem.EnergyValue = Convert.ToDecimal(item.value);
            energyItem.Room = room;
            // energyItem.Status = EntityStatus.Enabled;

            //var energyType = EnergyPortsCache.SingleOrDefault(s => s.Port == item.port);
            //if (energyType == null)
            //{
            //    return null;
            //}
            energyItem.EnergyType = energyTypeItem;
            return energyItem;
        }

        private void LogSyncErrorData(DateTime SyncDateTime, List<tb_data> syncOriginalList, Exception ex)
        {
            List<SyncDataLog> logs = new List<SyncDataLog>();

            foreach (var syncOriginalItem in syncOriginalList)
            {
                var logItem = new SyncDataLog();
                logItem.CreatedDate = SyncDateTime;
                logItem.SyncItemId = syncOriginalItem.id.ToString();
                logItem.SyncType = SyncType.EnergyItemResult;
                logItem.SyncError = ex.Message;
                logs.Add(logItem);
            }
            using (WriteableSqlDbContext wdbcontext = new WriteableSqlDbContext())
            {
                wdbcontext.SyncDataLogs.AddRange(logs);
                wdbcontext.SaveChanges();
            }

        }

        private void SaveSyncDateTime(DateTime SyncDateTime,string key)
        {
            //var SyncTimeComdict = NewEdmDb.Comdicts.SingleOrDefault(s => s.Type == "同步数据" && s.Key == "上次同步截止时间");
            var SyncTimeComdict = NewEdmDb.Comdicts.SingleOrDefault(s => s.Type == _syncComdictType && s.Key == key);

            if (SyncTimeComdict != null)
            {
                NewEdmDb.Entry(SyncTimeComdict).State = EntityState.Modified;
                NewEdmDb.SaveChanges();
            }
            else
            {
                //SyncTimeComdict = new Comdict() { CreateDate = DateTime.Now, Key = "上次同步截止时间", Type = "同步数据", Value = SyncDateTime.ToStringWithFullTime() };
                SyncTimeComdict = new Comdict() { CreateDate = DateTime.Now, Key = key, Type = _syncComdictType, Value = SyncDateTime.ToStringWithFullTime() };
                NewEdmDb.Comdicts.Add(SyncTimeComdict);
                NewEdmDb.SaveChanges();
            }
        }

        #endregion

    }
}
