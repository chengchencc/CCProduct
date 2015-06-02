using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CC.EDM.Model.RealEDMDb;
using EDMWebsite.Models.ViewModels;
using Newtonsoft.Json;

namespace CC.EDM.Domain.Services
{
    public interface IQueryService
    {
        void QueryByHourForBuildings(QueryModel model);
        void QueryByDayForBuildings(QueryModel model);
        void QueryByMonthForBuildings(QueryModel model);

        void QueryByHourForOneBuilding(QueryModel model);
        void QueryByDayForOneBuilding(QueryModel model);
        void QueryByMonthForOneBuilding(QueryModel model);
    }
    public class QueryService : IQueryService
    {
        public RealEDMDbContext edmDb { get; set; }

        public QueryService()
        {
            edmDb = new RealEDMDbContext();
        }
        
        public void QueryByHourForBuildings(QueryModel model)
        {

            var query = edmDb.T_EC_EnergyItemHourResult
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

        public void QueryByDayForBuildings(QueryModel model)
        {

            var query = edmDb.T_EC_EnergyItemDayResult
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
        
        public void QueryByMonthForBuildings(QueryModel model)
        {

            var query = edmDb.T_EC_EnergyItemMonthResult
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
            var query = edmDb.T_EC_EnergyItemHourResult
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


            model.HourResult = query.OrderBy(s=>s.F_StartHour).ToList();


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
                    dataItem.name = buildGroup.Key.ToString("HH")+"时";
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
            var query = edmDb.T_EC_EnergyItemDayResult
                             .Include(s => s.T_BD_BuildBaseInfo)
                             .Include(s => s.T_DT_EnergyItemDict)
                             .Where(s => s.F_BuildID == model.RoomCodes );

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
            var query = edmDb.T_EC_EnergyItemMonthResult
     .Include(s => s.T_BD_BuildBaseInfo)
     .Include(s => s.T_DT_EnergyItemDict)
     .Where(s => s.F_BuildID == model.RoomCodes );

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


    }
}
