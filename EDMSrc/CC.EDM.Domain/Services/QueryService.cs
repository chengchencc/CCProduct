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
namespace CC.EDM.Domain.Services
{
    public interface IQueryService
    {
        void QueryByHourForBuildingsOld(QueryModel model);
        void QueryByDayForBuildingsOld(QueryModel model);
        void QueryByMonthForBuildingsOld(QueryModel model);

        void QueryByHourForOneBuilding(QueryModel model);
        void QueryByDayForOneBuilding(QueryModel model);
        void QueryByMonthForOneBuilding(QueryModel model);


        void QueryByHourForRooms(QueryModel model);
        void QueryByDayForRooms(QueryModel model);
        void QueryByMonthForRooms(QueryModel model);

        void QueryByHourForInstitutes(QueryModel model);
        void QueryByDayForInstitutes(QueryModel model);
        void QueryByMonthForInstitutes(QueryModel model);

        void QueryByHourForBuildings(QueryModel model);
        void QueryByDayForBuildings(QueryModel model);
        void QueryByMonthForBuildings(QueryModel model);
    }
    public class QueryService : IQueryService
    {
        public RealEDMDbContext EdmDb { get; set; }
        public WriteableSqlDbContext NewEdmDb { get; set; }

        public QueryService()
        {
            EdmDb = new RealEDMDbContext();
            NewEdmDb = new WriteableSqlDbContext();
        }

        #region Old
        public void QueryByHourForBuildingsOld(QueryModel model)
        {

            var query = EdmDb.T_EC_EnergyItemHourResult
                 .Include("T_BD_BuildBaseInfo")
                 .Include("T_DT_EnergyItemDict")
                 .Where(s => 1 == 1);
            //.Where(s => codes.Contains(s.F_BuildID));

            if (!string.IsNullOrEmpty(model.RoomCodes)
    && !string.IsNullOrEmpty(model.RoomCodes.Trim(',')))
            {
                var roomCodesArray = model.RoomCodes.Trim(',').Split(',');
                query = query.Where(s => roomCodesArray.Contains(s.F_BuildID));
            }
            if (model.StartDate != null)
            {
                query = query.Where(s => s.F_StartHour >= model.StartDate);
            }
            if (model.EndDate != null)
            {
                query = query.Where(s => s.F_EndHour <= model.EndDate);
            }
            if (!string.IsNullOrEmpty(model.EnergyTypeCodes)
                && !string.IsNullOrEmpty(model.EnergyTypeCodes.Trim(',')))
            {
                var energyTypeCodesArray = model.EnergyTypeCodes.Trim(',').Split(',');
                query = query.Where(s => energyTypeCodesArray.Contains(s.F_EnergyItemCode));
            }
            model.HourResult = query.ToList();


            #region Chart Result

            List<ChartSeriesItem> seriesList = new List<ChartSeriesItem>();

            var energyTypeGroups = model.HourResult.GroupBy(s => s.T_DT_EnergyItemDict);//group by energy type
            foreach (var item in energyTypeGroups)
            {
                ChartSeriesItem seriesItem1 = new ChartSeriesItem();
                seriesItem1.name = item.Key.F_EnergyItemName;

                var buildGroups = item.GroupBy(s => s.T_BD_BuildBaseInfo);//group by build to sum the amount of energy in this data 
                foreach (var buildGroup in buildGroups)
                {
                    ChartSeriesDataItem dataItem = new ChartSeriesDataItem();
                    dataItem.id = buildGroup.Key.F_BuildID;
                    dataItem.name = buildGroup.Key.F_BuildName;
                    dataItem.y = buildGroup.Sum(s => s.F_HourValue);
                    dataItem.unit = item.Key.F_EnergyItemUnit;
                    seriesItem1.data.Add(dataItem);
                }

                seriesList.Add(seriesItem1);
            }
            model.ChartSeries = JsonConvert.SerializeObject(seriesList);

            #endregion

        }

        public void QueryByDayForBuildingsOld(QueryModel model)
        {

            var query = EdmDb.T_EC_EnergyItemDayResult
                 .Include("T_BD_BuildBaseInfo")
                 .Include("T_DT_EnergyItemDict")
                 .Where(s => 1 == 1);
            //.Where(s => codes.Contains(s.F_BuildID));

            if (!string.IsNullOrEmpty(model.RoomCodes)
    && !string.IsNullOrEmpty(model.RoomCodes.Trim(',')))
            {
                var roomCodesArray = model.RoomCodes.Trim(',').Split(',');
                query = query.Where(s => roomCodesArray.Contains(s.F_BuildID));
            }
            if (model.StartDate != null)
            {
                query = query.Where(s => s.F_StartDay >= model.StartDate);
            }
            if (model.EndDate != null)
            {
                query = query.Where(s => s.F_EndDay <= model.EndDate);
            }
            if (!string.IsNullOrEmpty(model.EnergyTypeCodes)
                && !string.IsNullOrEmpty(model.EnergyTypeCodes.Trim(',')))
            {
                var energyTypeCodesArray = model.EnergyTypeCodes.Trim(',').Split(',');
                query = query.Where(s => energyTypeCodesArray.Contains(s.F_EnergyItemCode));
            }
            model.DayResult = query.ToList();


            #region Chart Result

            List<ChartSeriesItem> seriesList = new List<ChartSeriesItem>();

            var energyTypeGroups = model.DayResult.GroupBy(s => s.T_DT_EnergyItemDict);//group by energy type
            var a = energyTypeGroups.ToList();
            foreach (var item in energyTypeGroups)
            {
                ChartSeriesItem seriesItem1 = new ChartSeriesItem();
                seriesItem1.name = item.Key.F_EnergyItemName;
                var buildGroups = item.GroupBy(s => s.T_BD_BuildBaseInfo);//group by build to sum the amount of energy in this data 
                foreach (var buildGroup in buildGroups)
                {
                    ChartSeriesDataItem dataItem = new ChartSeriesDataItem();
                    dataItem.id = buildGroup.Key.F_BuildID;
                    dataItem.name = buildGroup.Key.F_BuildName;
                    dataItem.y = buildGroup.Sum(s => s.F_DayValue);
                    dataItem.unit = item.Key.F_EnergyItemUnit;
                    seriesItem1.data.Add(dataItem);
                }

                seriesList.Add(seriesItem1);
            }
            model.ChartSeries = JsonConvert.SerializeObject(seriesList);

            #endregion

        }

        public void QueryByMonthForBuildingsOld(QueryModel model)
        {

            var query = EdmDb.T_EC_EnergyItemMonthResult
                 .Include("T_BD_BuildBaseInfo")
                 .Include("T_DT_EnergyItemDict")
                 .Where(s => 1 == 1);
            //.Where(s => codes.Contains(s.F_BuildID));

            if (!string.IsNullOrEmpty(model.RoomCodes)
    && !string.IsNullOrEmpty(model.RoomCodes.Trim(',')))
            {
                var roomCodesArray = model.RoomCodes.Trim(',').Split(',');
                query = query.Where(s => roomCodesArray.Contains(s.F_BuildID));
            }
            if (model.StartDate != null)
            {
                query = query.Where(s => s.F_StartMonth >= model.StartDate);
            }
            if (model.EndDate != null)
            {
                query = query.Where(s => s.F_EndMonth <= model.EndDate);
            }
            if (!string.IsNullOrEmpty(model.EnergyTypeCodes)
                && !string.IsNullOrEmpty(model.EnergyTypeCodes.Trim(',')))
            {
                var energyTypeCodesArray = model.EnergyTypeCodes.Trim(',').Split(',');
                query = query.Where(s => energyTypeCodesArray.Contains(s.F_EnergyItemCode));
            }
            model.MonthResult = query.ToList();


            #region Chart Result

            List<ChartSeriesItem> seriesList = new List<ChartSeriesItem>();

            var energyTypeGroups = model.MonthResult.GroupBy(s => s.T_DT_EnergyItemDict);//group by energy type
            var a = energyTypeGroups.ToList();
            foreach (var item in energyTypeGroups)
            {
                ChartSeriesItem seriesItem1 = new ChartSeriesItem();
                seriesItem1.name = item.Key.F_EnergyItemName;
                //foreach (var groupItem in item)
                //{
                var buildGroups = item.GroupBy(s => s.T_BD_BuildBaseInfo);//group by build to sum the amount of energy in this data 
                foreach (var buildGroup in buildGroups)
                {
                    ChartSeriesDataItem dataItem = new ChartSeriesDataItem();
                    dataItem.id = buildGroup.Key.F_BuildID;
                    dataItem.name = buildGroup.Key.F_BuildName;
                    dataItem.y = buildGroup.Sum(s => s.F_MonthValue);
                    dataItem.unit = item.Key.F_EnergyItemUnit;
                    seriesItem1.data.Add(dataItem);
                }

                seriesList.Add(seriesItem1);
            }
            model.ChartSeries = JsonConvert.SerializeObject(seriesList);

            #endregion

        }



        public void QueryByHourForOneBuilding(QueryModel model)
        {
            var query = EdmDb.T_EC_EnergyItemHourResult
     .Include(s => s.T_BD_BuildBaseInfo)
     .Include(s => s.T_DT_EnergyItemDict)
     .Where(s => s.F_BuildID == model.RoomCodes);
            //.OrderBy(s => s.F_StartHour);

            if (model.StartDate != null)
            {
                query = query.Where(s => s.F_StartHour >= model.StartDate);
            }
            if (model.EndDate != null)
            {
                query = query.Where(s => s.F_EndHour <= model.EndDate);
            }
            if (!string.IsNullOrEmpty(model.EnergyTypeCodes)
                && !string.IsNullOrEmpty(model.EnergyTypeCodes.Trim(',')))
            {
                var energyTypeCodesArray = model.EnergyTypeCodes.Trim(',').Split(',');
                query = query.Where(s => energyTypeCodesArray.Contains(s.F_EnergyItemCode));
            }


            model.HourResult = query.OrderBy(s => s.F_StartHour).ToList();


            #region Chart Result

            List<ChartSeriesItem> seriesList = new List<ChartSeriesItem>();

            var energyTypeGroups = model.HourResult.GroupBy(s => s.T_DT_EnergyItemDict);//group by energy type
            foreach (var item in energyTypeGroups)
            {
                ChartSeriesItem seriesItem1 = new ChartSeriesItem();
                seriesItem1.name = item.Key.F_EnergyItemName;
                //seriesItem1.colorByPoint = true;

                var hourGroups = item.OrderBy(s => s.F_StartHour).GroupBy(s => s.F_StartHour);//group by build to sum the amount of energy in this data 
                foreach (var buildGroup in hourGroups)
                {
                    ChartSeriesDataItem dataItem = new ChartSeriesDataItem();
                    dataItem.id = buildGroup.Key.ToString("yyyy-MM-dd HH");
                    dataItem.name = buildGroup.Key.ToString("HH") + "时";
                    dataItem.y = buildGroup.Sum(s => s.F_HourValue);
                    dataItem.unit = item.Key.F_EnergyItemUnit;
                    seriesItem1.data.Add(dataItem);
                }
                seriesList.Add(seriesItem1);
            }
            model.ChartSeries = JsonConvert.SerializeObject(seriesList);

            #endregion
        }

        public void QueryByDayForOneBuilding(QueryModel model)
        {
            var query = EdmDb.T_EC_EnergyItemDayResult
                             .Include(s => s.T_BD_BuildBaseInfo)
                             .Include(s => s.T_DT_EnergyItemDict)
                             .Where(s => s.F_BuildID == model.RoomCodes);

            if (model.StartDate != null)
            {
                query = query.Where(s => s.F_StartDay >= model.StartDate);
            }
            if (model.EndDate != null)
            {
                query = query.Where(s => s.F_EndDay <= model.EndDate);
            }
            if (!string.IsNullOrEmpty(model.EnergyTypeCodes)
                && !string.IsNullOrEmpty(model.EnergyTypeCodes.Trim(',')))
            {
                var energyTypeCodesArray = model.EnergyTypeCodes.Trim(',').Split(',');
                query = query.Where(s => energyTypeCodesArray.Contains(s.F_EnergyItemCode));
            }


            model.DayResult = query.OrderBy(s => s.F_StartDay).ToList();//.ToList();


            #region Chart Result

            List<ChartSeriesItem> seriesList = new List<ChartSeriesItem>();

            var energyTypeGroups = model.DayResult.GroupBy(s => s.T_DT_EnergyItemDict);//group by energy type
            foreach (var item in energyTypeGroups)
            {
                ChartSeriesItem seriesItem1 = new ChartSeriesItem();
                seriesItem1.name = item.Key.F_EnergyItemName;
                //seriesItem1.colorByPoint = true;

                var hourGroups = item.OrderBy(s => s.F_StartDay).GroupBy(s => s.F_StartDay);//group by build to sum the amount of energy in this data 
                foreach (var buildGroup in hourGroups)
                {
                    ChartSeriesDataItem dataItem = new ChartSeriesDataItem();
                    dataItem.id = buildGroup.Key.ToString("yyyy-MM-dd");
                    dataItem.name = buildGroup.Key.ToString("dd") + "日";
                    //dataItem.name = buildGroup.Key.ToString("yyyy-MM-dd") + "日";
                    dataItem.y = buildGroup.Sum(s => s.F_DayValue);
                    dataItem.unit = item.Key.F_EnergyItemUnit;
                    seriesItem1.data.Add(dataItem);
                }

                seriesList.Add(seriesItem1);
            }
            model.ChartSeries = JsonConvert.SerializeObject(seriesList);

            #endregion
        }

        public void QueryByMonthForOneBuilding(QueryModel model)
        {
            var query = EdmDb.T_EC_EnergyItemMonthResult
     .Include(s => s.T_BD_BuildBaseInfo)
     .Include(s => s.T_DT_EnergyItemDict)
     .Where(s => s.F_BuildID == model.RoomCodes);

            if (model.StartDate != null)
            {
                query = query.Where(s => s.F_StartMonth >= model.StartDate);
            }
            if (model.EndDate != null)
            {
                query = query.Where(s => s.F_EndMonth <= model.EndDate);
            }
            if (!string.IsNullOrEmpty(model.EnergyTypeCodes)
                && !string.IsNullOrEmpty(model.EnergyTypeCodes.Trim(',')))
            {
                var energyTypeCodesArray = model.EnergyTypeCodes.Trim(',').Split(',');
                query = query.Where(s => energyTypeCodesArray.Contains(s.F_EnergyItemCode));
            }


            model.MonthResult = query.OrderBy(s => s.F_StartMonth).ToList();


            #region Chart Result

            List<ChartSeriesItem> seriesList = new List<ChartSeriesItem>();

            var energyTypeGroups = model.MonthResult.GroupBy(s => s.T_DT_EnergyItemDict);//group by energy type
            foreach (var item in energyTypeGroups)
            {
                ChartSeriesItem seriesItem1 = new ChartSeriesItem();
                seriesItem1.name = item.Key.F_EnergyItemName;
                //seriesItem1.colorByPoint = true;

                var hourGroups = item.OrderBy(s => s.F_StartMonth).GroupBy(s => s.F_StartMonth);//group by build to sum the amount of energy in this data 
                foreach (var buildGroup in hourGroups)
                {
                    ChartSeriesDataItem dataItem = new ChartSeriesDataItem();
                    dataItem.id = buildGroup.Key.ToString("yyyy-MM");
                    dataItem.name = buildGroup.Key.ToString("MM") + "月";
                    //dataItem.name = buildGroup.Key.ToString("yyyy-MM") + "月";
                    dataItem.y = buildGroup.Sum(s => s.F_MonthValue);
                    dataItem.unit = item.Key.F_EnergyItemUnit;
                    seriesItem1.data.Add(dataItem);
                }

                seriesList.Add(seriesItem1);
            }
            model.ChartSeries = JsonConvert.SerializeObject(seriesList);

            #endregion
        }

        #endregion

        #region Rooms
        public void QueryByHourForRooms(QueryModel model)
        {

            var query = NewEdmDb.EnergyItemHourResults
                .Include(s => s.Room)
                 .Where(s => 1 == 1);
            //.Where(s => codes.Contains(s.F_BuildID));

            if (!string.IsNullOrEmpty(model.RoomCodes)
&& !string.IsNullOrEmpty(model.RoomCodes.Trim(',')))
            {
                var roomCodesArray = model.RoomCodes.Trim(',').Split(',');
                query = query.Where(s => roomCodesArray.Contains(s.Room.Id.ToString()));
            }

            //if (model.Rooms != null && model.Rooms.Count > 0)
            //{
            //    //var roomCodesArray = model.RoomCodes.Trim(',').Split(',');
            //    query = query.Where(s => model.Rooms.Contains(s.Room.Id.ToString()));
            //}
            if (model.StartDate != null)
            {
                query = query.Where(s => s.StartDate >= model.StartDate);
            }
            if (model.EndDate != null)
            {
                query = query.Where(s => s.EndDate <= model.EndDate);
            }
            if (!string.IsNullOrEmpty(model.EnergyTypeCodes)
                && !string.IsNullOrEmpty(model.EnergyTypeCodes.Trim(',')))
            {
                var energyTypeCodesArray = model.EnergyTypeCodes.Trim(',').Split(',');
                query = query.Where(s => energyTypeCodesArray.Contains(s.EnergyType.F_EnergyItemCode));
            }
            //model.HourResult = query.ToList();
            model.NewHourResult = query.ToList();

            #region Chart Result

            List<ChartSeriesItem> seriesList = new List<ChartSeriesItem>();

            var energyTypeGroups = model.NewHourResult.GroupBy(s => s.EnergyType);//group by energy type
            foreach (var item in energyTypeGroups)
            {
                ChartSeriesItem seriesItem = new ChartSeriesItem();
                seriesItem.name = item.Key.F_EnergyItemName;

                var buildGroups = item.GroupBy(s => s.Room);//group by build to sum the amount of energy in this data 
                foreach (var buildGroup in buildGroups)
                {
                    ChartSeriesDataItem dataItem = new ChartSeriesDataItem();
                    dataItem.id = buildGroup.Key.Id.ToString();
                    dataItem.name = buildGroup.Key.Name;
                    dataItem.y = buildGroup.Sum(s => s.EnergyValue);
                    dataItem.unit = item.Key.F_EnergyItemUnit;
                    seriesItem.data.Add(dataItem);
                }

                seriesList.Add(seriesItem);
            }
            model.ChartSeries = JsonConvert.SerializeObject(seriesList);

            #endregion

        }
        public void QueryByDayForRooms(QueryModel model)
        {

            var query = NewEdmDb.EnergyItemDayResults
                .Include(s => s.Room)
                 .Where(s => 1 == 1);
            //.Where(s => codes.Contains(s.F_BuildID));

            if (!string.IsNullOrEmpty(model.RoomCodes)
&& !string.IsNullOrEmpty(model.RoomCodes.Trim(',')))
            {
                var roomCodesArray = model.RoomCodes.Trim(',').Split(',');
                query = query.Where(s => roomCodesArray.Contains(s.Room.Id.ToString()));
            }
            //if (model.Rooms != null && model.Rooms.Count > 0)
            //{
            //    //var roomCodesArray = model.RoomCodes.Trim(',').Split(',');
            //    query = query.Where(s => model.Rooms.Contains(s.Room.InstituteId.ToString()));
            //}
            if (model.StartDate != null)
            {
                query = query.Where(s => s.StartDate >= model.StartDate);
            }
            if (model.EndDate != null)
            {
                query = query.Where(s => s.EndDate <= model.EndDate);
            }
            if (!string.IsNullOrEmpty(model.EnergyTypeCodes)
                && !string.IsNullOrEmpty(model.EnergyTypeCodes.Trim(',')))
            {
                var energyTypeCodesArray = model.EnergyTypeCodes.Trim(',').Split(',');
                query = query.Where(s => energyTypeCodesArray.Contains(s.EnergyType.F_EnergyItemCode));
            }
            //model.HourResult = query.ToList();
            model.NewDayResult = query.ToList();

            #region Chart Result

            List<ChartSeriesItem> seriesList = new List<ChartSeriesItem>();

            var energyTypeGroups = model.NewDayResult.GroupBy(s => s.EnergyType);//group by energy type
            foreach (var item in energyTypeGroups)
            {
                ChartSeriesItem seriesItem = new ChartSeriesItem();
                seriesItem.name = item.Key.F_EnergyItemName;

                var buildGroups = item.GroupBy(s => s.Room);//group by build to sum the amount of energy in this data 
                foreach (var buildGroup in buildGroups)
                {
                    ChartSeriesDataItem dataItem = new ChartSeriesDataItem();
                    dataItem.id = buildGroup.Key.Id.ToString();
                    dataItem.name = buildGroup.Key.Name;
                    dataItem.y = buildGroup.Sum(s => s.EnergyValue);
                    dataItem.unit = item.Key.F_EnergyItemUnit;
                    seriesItem.data.Add(dataItem);
                }

                seriesList.Add(seriesItem);
            }
            model.ChartSeries = JsonConvert.SerializeObject(seriesList);

            #endregion

        }
        public void QueryByMonthForRooms(QueryModel model)
        {

            var query = NewEdmDb.EnergyItemMonthResult
                .Include(s => s.Room)
                 .Where(s => 1 == 1);
            //.Where(s => codes.Contains(s.F_BuildID));
            if (!string.IsNullOrEmpty(model.RoomCodes)
&& !string.IsNullOrEmpty(model.RoomCodes.Trim(',')))
            {
                var roomCodesArray = model.RoomCodes.Trim(',').Split(',');
                query = query.Where(s => roomCodesArray.Contains(s.Room.Id.ToString()));
            }
            //if (model.Rooms != null && model.Rooms.Count > 0)
            //{
            //    //var roomCodesArray = model.RoomCodes.Trim(',').Split(',');
            //    query = query.Where(s => model.Rooms.Contains(s.Room.InstituteId.ToString()));
            //}
            if (model.StartDate != null)
            {
                query = query.Where(s => s.StartDate >= model.StartDate);
            }
            if (model.EndDate != null)
            {
                query = query.Where(s => s.EndDate <= model.EndDate);
            }
            if (!string.IsNullOrEmpty(model.EnergyTypeCodes)
                && !string.IsNullOrEmpty(model.EnergyTypeCodes.Trim(',')))
            {
                var energyTypeCodesArray = model.EnergyTypeCodes.Trim(',').Split(',');
                query = query.Where(s => energyTypeCodesArray.Contains(s.EnergyType.F_EnergyItemCode));
            }
            //model.HourResult = query.ToList();
            model.NewMonthResult = query.ToList();

            #region Chart Result

            List<ChartSeriesItem> seriesList = new List<ChartSeriesItem>();

            var energyTypeGroups = model.NewMonthResult.GroupBy(s => s.EnergyType);//group by energy type
            foreach (var item in energyTypeGroups)
            {
                ChartSeriesItem seriesItem = new ChartSeriesItem();
                seriesItem.name = item.Key.F_EnergyItemName;

                var buildGroups = item.GroupBy(s => s.Room);//group by build to sum the amount of energy in this data 
                foreach (var buildGroup in buildGroups)
                {
                    ChartSeriesDataItem dataItem = new ChartSeriesDataItem();
                    dataItem.id = buildGroup.Key.Id.ToString();
                    dataItem.name = buildGroup.Key.Name;
                    dataItem.y = buildGroup.Sum(s => s.EnergyValue);
                    dataItem.unit = item.Key.F_EnergyItemUnit;
                    seriesItem.data.Add(dataItem);
                }

                seriesList.Add(seriesItem);
            }
            model.ChartSeries = JsonConvert.SerializeObject(seriesList);

            #endregion

        }
        #endregion

        #region Institutes
        public void QueryByHourForInstitutes(QueryModel model)
        {

            var query = NewEdmDb.EnergyItemHourResults
                .Include(s => s.Room)
                 .Where(s => 1 == 1);

            if (model.Rooms != null && model.Rooms.Count > 0)
            {
                query = query.Where(s => model.Rooms.Contains(s.Room.InstituteId.ToString()));
            }
            if (model.StartDate != null)
            {
                query = query.Where(s => s.StartDate >= model.StartDate);
            }
            if (model.EndDate != null)
            {
                query = query.Where(s => s.EndDate <= model.EndDate);
            }
            if (!string.IsNullOrEmpty(model.EnergyTypeCodes)
                && !string.IsNullOrEmpty(model.EnergyTypeCodes.Trim(',')))
            {
                var energyTypeCodesArray = model.EnergyTypeCodes.Trim(',').Split(',');
                query = query.Where(s => energyTypeCodesArray.Contains(s.EnergyType.F_EnergyItemCode));
            }
            //model.HourResult = query.ToList();
            model.NewHourResult = query.ToList();

            #region Chart Result

            List<ChartSeriesItem> seriesList = new List<ChartSeriesItem>();

            var energyTypeGroups = model.NewHourResult.GroupBy(s => s.EnergyType);//group by energy type
            foreach (var item in energyTypeGroups)
            {
                ChartSeriesItem seriesItem = new ChartSeriesItem();
                seriesItem.name = item.Key.F_EnergyItemName;

                var buildGroups = item.GroupBy(s => s.Room.Institute);//group by build to sum the amount of energy in this data 
                foreach (var buildGroup in buildGroups)
                {
                    ChartSeriesDataItem dataItem = new ChartSeriesDataItem();
                    dataItem.id = buildGroup.Key.Id.ToString();
                    dataItem.name = buildGroup.Key.Name;
                    dataItem.y = buildGroup.Sum(s => s.EnergyValue);
                    dataItem.unit = item.Key.F_EnergyItemUnit;
                    seriesItem.data.Add(dataItem);
                }

                seriesList.Add(seriesItem);
            }
            model.ChartSeries = JsonConvert.SerializeObject(seriesList);

            #endregion

        }
        public void QueryByDayForInstitutes(QueryModel model)
        {

            var query = NewEdmDb.EnergyItemDayResults
                .Include(s => s.Room)
                 .Where(s => 1 == 1);
            //.Where(s => codes.Contains(s.F_BuildID));

            if (model.Rooms != null && model.Rooms.Count > 0)
            {
                //var roomCodesArray = model.RoomCodes.Trim(',').Split(',');
                query = query.Where(s => model.Rooms.Contains(s.Room.InstituteId.ToString()));
            }
            if (model.StartDate != null)
            {
                query = query.Where(s => s.StartDate >= model.StartDate);
            }
            if (model.EndDate != null)
            {
                query = query.Where(s => s.EndDate <= model.EndDate);
            }
            if (!string.IsNullOrEmpty(model.EnergyTypeCodes)
                && !string.IsNullOrEmpty(model.EnergyTypeCodes.Trim(',')))
            {
                var energyTypeCodesArray = model.EnergyTypeCodes.Trim(',').Split(',');
                query = query.Where(s => energyTypeCodesArray.Contains(s.EnergyType.F_EnergyItemCode));
            }
            //model.HourResult = query.ToList();
            model.NewDayResult = query.ToList();

            #region Chart Result

            List<ChartSeriesItem> seriesList = new List<ChartSeriesItem>();

            var energyTypeGroups = model.NewDayResult.GroupBy(s => s.EnergyType);//group by energy type
            foreach (var item in energyTypeGroups)
            {
                ChartSeriesItem seriesItem = new ChartSeriesItem();
                seriesItem.name = item.Key.F_EnergyItemName;

                var buildGroups = item.GroupBy(s => s.Room.Institute);//group by build to sum the amount of energy in this data 
                foreach (var buildGroup in buildGroups)
                {
                    ChartSeriesDataItem dataItem = new ChartSeriesDataItem();
                    dataItem.id = buildGroup.Key.Id.ToString();
                    dataItem.name = buildGroup.Key.Name;
                    dataItem.y = buildGroup.Sum(s => s.EnergyValue);
                    dataItem.unit = item.Key.F_EnergyItemUnit;
                    seriesItem.data.Add(dataItem);
                }

                seriesList.Add(seriesItem);
            }
            model.ChartSeries = JsonConvert.SerializeObject(seriesList);

            #endregion

        }
        public void QueryByMonthForInstitutes(QueryModel model)
        {

            var query = NewEdmDb.EnergyItemMonthResult
                .Include(s => s.Room)
                 .Where(s => 1 == 1);
            //.Where(s => codes.Contains(s.F_BuildID));

            if (model.Rooms != null && model.Rooms.Count > 0)
            {
                //var roomCodesArray = model.RoomCodes.Trim(',').Split(',');
                query = query.Where(s => model.Rooms.Contains(s.Room.InstituteId.ToString()));
            }
            if (model.StartDate != null)
            {
                query = query.Where(s => s.StartDate >= model.StartDate);
            }
            if (model.EndDate != null)
            {
                query = query.Where(s => s.EndDate <= model.EndDate);
            }
            if (!string.IsNullOrEmpty(model.EnergyTypeCodes)
                && !string.IsNullOrEmpty(model.EnergyTypeCodes.Trim(',')))
            {
                var energyTypeCodesArray = model.EnergyTypeCodes.Trim(',').Split(',');
                query = query.Where(s => energyTypeCodesArray.Contains(s.EnergyType.F_EnergyItemCode));
            }
            //model.HourResult = query.ToList();
            model.NewMonthResult = query.ToList();

            #region Chart Result

            List<ChartSeriesItem> seriesList = new List<ChartSeriesItem>();

            var energyTypeGroups = model.NewMonthResult.GroupBy(s => s.EnergyType);//group by energy type
            foreach (var item in energyTypeGroups)
            {
                ChartSeriesItem seriesItem = new ChartSeriesItem();
                seriesItem.name = item.Key.F_EnergyItemName;

                var buildGroups = item.GroupBy(s => s.Room.Institute);//group by build to sum the amount of energy in this data 
                foreach (var buildGroup in buildGroups)
                {
                    ChartSeriesDataItem dataItem = new ChartSeriesDataItem();
                    dataItem.id = buildGroup.Key.Id.ToString();
                    dataItem.name = buildGroup.Key.Name;
                    dataItem.y = buildGroup.Sum(s => s.EnergyValue);
                    dataItem.unit = item.Key.F_EnergyItemUnit;
                    seriesItem.data.Add(dataItem);
                }

                seriesList.Add(seriesItem);
            }
            model.ChartSeries = JsonConvert.SerializeObject(seriesList);

            #endregion

        }

        #endregion

        #region Buildings
        public void QueryByHourForBuildings(QueryModel model)
        {

            var query = NewEdmDb.EnergyItemHourResults
                .Include(s => s.Room)
                 .Where(s => 1 == 1);

            if (model.Rooms != null && model.Rooms.Count > 0)
            {
                query = query.Where(s => model.Rooms.Contains(s.Room.BuildingId.ToString()));
            }
            if (model.StartDate != null)
            {
                query = query.Where(s => s.StartDate >= model.StartDate);
            }
            if (model.EndDate != null)
            {
                query = query.Where(s => s.EndDate <= model.EndDate);
            }
            if (!string.IsNullOrEmpty(model.EnergyTypeCodes)
                && !string.IsNullOrEmpty(model.EnergyTypeCodes.Trim(',')))
            {
                var energyTypeCodesArray = model.EnergyTypeCodes.Trim(',').Split(',');
                query = query.Where(s => energyTypeCodesArray.Contains(s.EnergyType.F_EnergyItemCode));
            }
            //model.HourResult = query.ToList();
            model.NewHourResult = query.ToList();

            #region Chart Result

            List<ChartSeriesItem> seriesList = new List<ChartSeriesItem>();

            var energyTypeGroups = model.NewHourResult.GroupBy(s => s.EnergyType);//group by energy type
            foreach (var item in energyTypeGroups)
            {
                ChartSeriesItem seriesItem = new ChartSeriesItem();
                seriesItem.name = item.Key.F_EnergyItemName;

                var buildGroups = item.GroupBy(s => s.Room.Building);//group by build to sum the amount of energy in this data 
                foreach (var buildGroup in buildGroups)
                {
                    ChartSeriesDataItem dataItem = new ChartSeriesDataItem();
                    dataItem.id = buildGroup.Key.Id.ToString();
                    dataItem.name = buildGroup.Key.Name;
                    dataItem.y = buildGroup.Sum(s => s.EnergyValue);
                    dataItem.unit = item.Key.F_EnergyItemUnit;
                    seriesItem.data.Add(dataItem);
                }

                seriesList.Add(seriesItem);
            }
            model.ChartSeries = JsonConvert.SerializeObject(seriesList);

            #endregion

        }
        public void QueryByDayForBuildings(QueryModel model)
        {

            var query = NewEdmDb.EnergyItemDayResults
                .Include(s => s.Room)
                 .Where(s => 1 == 1);
            //.Where(s => codes.Contains(s.F_BuildID));

            if (model.Rooms != null && model.Rooms.Count > 0)
            {
                //var roomCodesArray = model.RoomCodes.Trim(',').Split(',');
                query = query.Where(s => model.Rooms.Contains(s.Room.BuildingId.ToString()));
            }
            if (model.StartDate != null)
            {
                query = query.Where(s => s.StartDate >= model.StartDate);
            }
            if (model.EndDate != null)
            {
                query = query.Where(s => s.EndDate <= model.EndDate);
            }
            if (!string.IsNullOrEmpty(model.EnergyTypeCodes)
                && !string.IsNullOrEmpty(model.EnergyTypeCodes.Trim(',')))
            {
                var energyTypeCodesArray = model.EnergyTypeCodes.Trim(',').Split(',');
                query = query.Where(s => energyTypeCodesArray.Contains(s.EnergyType.F_EnergyItemCode));
            }
            //model.HourResult = query.ToList();
            model.NewDayResult = query.ToList();

            #region Chart Result

            List<ChartSeriesItem> seriesList = new List<ChartSeriesItem>();

            var energyTypeGroups = model.NewDayResult.GroupBy(s => s.EnergyType);//group by energy type
            foreach (var item in energyTypeGroups)
            {
                ChartSeriesItem seriesItem = new ChartSeriesItem();
                seriesItem.name = item.Key.F_EnergyItemName;

                var buildGroups = item.GroupBy(s => s.Room.Building);//group by build to sum the amount of energy in this data 
                foreach (var buildGroup in buildGroups)
                {
                    ChartSeriesDataItem dataItem = new ChartSeriesDataItem();
                    dataItem.id = buildGroup.Key.Id.ToString();
                    dataItem.name = buildGroup.Key.Name;
                    dataItem.y = buildGroup.Sum(s => s.EnergyValue);
                    dataItem.unit = item.Key.F_EnergyItemUnit;
                    seriesItem.data.Add(dataItem);
                }

                seriesList.Add(seriesItem);
            }
            model.ChartSeries = JsonConvert.SerializeObject(seriesList);

            #endregion

        }
        public void QueryByMonthForBuildings(QueryModel model)
        {

            var query = NewEdmDb.EnergyItemMonthResult
                .Include(s => s.Room)
                 .Where(s => 1 == 1);
            //.Where(s => codes.Contains(s.F_BuildID));

            if (model.Rooms != null && model.Rooms.Count > 0)
            {
                //var roomCodesArray = model.RoomCodes.Trim(',').Split(',');
                query = query.Where(s => model.Rooms.Contains(s.Room.BuildingId.ToString()));
            }
            if (model.StartDate != null)
            {
                query = query.Where(s => s.StartDate >= model.StartDate);
            }
            if (model.EndDate != null)
            {
                query = query.Where(s => s.EndDate <= model.EndDate);
            }
            if (!string.IsNullOrEmpty(model.EnergyTypeCodes)
                && !string.IsNullOrEmpty(model.EnergyTypeCodes.Trim(',')))
            {
                var energyTypeCodesArray = model.EnergyTypeCodes.Trim(',').Split(',');
                query = query.Where(s => energyTypeCodesArray.Contains(s.EnergyType.F_EnergyItemCode));
            }
            //model.HourResult = query.ToList();
            model.NewMonthResult = query.ToList();

            #region Chart Result

            List<ChartSeriesItem> seriesList = new List<ChartSeriesItem>();

            var energyTypeGroups = model.NewMonthResult.GroupBy(s => s.EnergyType);//group by energy type
            foreach (var item in energyTypeGroups)
            {
                ChartSeriesItem seriesItem = new ChartSeriesItem();
                seriesItem.name = item.Key.F_EnergyItemName;

                var buildGroups = item.GroupBy(s => s.Room.Building);//group by build to sum the amount of energy in this data 
                foreach (var buildGroup in buildGroups)
                {
                    ChartSeriesDataItem dataItem = new ChartSeriesDataItem();
                    dataItem.id = buildGroup.Key.Id.ToString();
                    dataItem.name = buildGroup.Key.Name;
                    dataItem.y = buildGroup.Sum(s => s.EnergyValue);
                    dataItem.unit = item.Key.F_EnergyItemUnit;
                    seriesItem.data.Add(dataItem);
                }

                seriesList.Add(seriesItem);
            }
            model.ChartSeries = JsonConvert.SerializeObject(seriesList);

            #endregion

        }

        #endregion

    }
}
