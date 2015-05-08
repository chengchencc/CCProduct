using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using EDMWebsite.Models.DbModels.ReadOnly;
namespace EDMWebsite
{
    public partial class EDMContext : DbContext
    {
        public EDMContext()
            : base("name=EDMContext")
        {
        }
        static EDMContext()
        {
            Database.SetInitializer<ReadOnlySqlDbContext>(null);
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<T_BD_BuildAddFile> T_BD_BuildAddFile { get; set; }
        public virtual DbSet<T_BD_BuildBaseInfo> T_BD_BuildBaseInfo { get; set; }
        public virtual DbSet<T_BD_BuildEngyConsRenoInfo> T_BD_BuildEngyConsRenoInfo { get; set; }
        public virtual DbSet<T_BD_BuildExInfo> T_BD_BuildExInfo { get; set; }
        public virtual DbSet<T_BD_BuildGroupBaseInfo> T_BD_BuildGroupBaseInfo { get; set; }
        public virtual DbSet<T_DC_CityTempInfo> T_DC_CityTempInfo { get; set; }
        public virtual DbSet<T_DC_DataCenterBaseInfo> T_DC_DataCenterBaseInfo { get; set; }
        public virtual DbSet<T_DT_EnergyItemDict> T_DT_EnergyItemDict { get; set; }
        public virtual DbSet<T_EC_EnergyItemDayResult> T_EC_EnergyItemDayResult { get; set; }
        public virtual DbSet<T_EC_EnergyItemHourResult> T_EC_EnergyItemHourResult { get; set; }
        public virtual DbSet<T_EC_EnergyItemResult> T_EC_EnergyItemResult { get; set; }
        public virtual DbSet<T_EC_RoomEnergyItemDayResult> T_EC_RoomEnergyItemDayResult { get; set; }
        public virtual DbSet<T_EC_RoomEnergyItemHourResult> T_EC_RoomEnergyItemHourResult { get; set; }
        public virtual DbSet<T_EC_RoomEnergyItemMonthResult> T_EC_RoomEnergyItemMonthResult { get; set; }
        public virtual DbSet<T_EC_RoomEnergyItemResult> T_EC_RoomEnergyItemResult { get; set; }
        public virtual DbSet<T_EC_UnitEnergyItemDayResult> T_EC_UnitEnergyItemDayResult { get; set; }
        public virtual DbSet<T_EC_UnitEnergyItemHourResult> T_EC_UnitEnergyItemHourResult { get; set; }
        public virtual DbSet<T_EC_UnitEnergyItemResult> T_EC_UnitEnergyItemResult { get; set; }
        public virtual DbSet<T_RM_RoomInfo> T_RM_RoomInfo { get; set; }
        public virtual DbSet<T_ST_CircuitMeterInfo> T_ST_CircuitMeterInfo { get; set; }
        public virtual DbSet<T_ST_DataCollectionInfo> T_ST_DataCollectionInfo { get; set; }
        public virtual DbSet<T_ST_MeterParamInfo> T_ST_MeterParamInfo { get; set; }
        public virtual DbSet<T_ST_MeterProdInfo> T_ST_MeterProdInfo { get; set; }
        public virtual DbSet<T_UT_UnitBaseInfo> T_UT_UnitBaseInfo { get; set; }
        public virtual DbSet<T_OV_MeterOrigValue> T_OV_MeterOrigValue { get; set; }
        public virtual DbSet<T_ST_MeterUseInfo> T_ST_MeterUseInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_BD_BuildAddFile>()
                .Property(e => e.F_FileID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildAddFile>()
                .Property(e => e.F_BuildID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildAddFile>()
                .Property(e => e.F_FileFuncType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildAddFile>()
                .Property(e => e.F_FileFormatType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildAddFile>()
                .Property(e => e.F_FileDesc)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildAddFile>()
                .Property(e => e.F_FilePath)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_BuildID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_DataCenterID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_BuildName)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_AliasName)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_BuildOwner)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_DistrictCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_BuildAddr)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_BuildLong)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_BuildLat)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_BuildYear)
                .HasPrecision(4, 0);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_BuildFunc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_TotalArea)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_AirArea)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_HeatArea)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_AirType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_HeatType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_BodyCoef)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_StruType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_WallMatType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_WallWarmType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_WallWinType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_GlassType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_WinFrameType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_DesignDept)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_WorkDept)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .Property(e => e.F_CreateUser)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .HasMany(e => e.T_BD_BuildAddFile)
                .WithRequired(e => e.T_BD_BuildBaseInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .HasMany(e => e.T_BD_BuildEngyConsRenoInfo)
                .WithRequired(e => e.T_BD_BuildBaseInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .HasOptional(e => e.T_BD_BuildExInfo)
                .WithRequired(e => e.T_BD_BuildBaseInfo);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .HasMany(e => e.T_EC_EnergyItemDayResult)
                .WithRequired(e => e.T_BD_BuildBaseInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .HasMany(e => e.T_EC_EnergyItemHourResult)
                .WithRequired(e => e.T_BD_BuildBaseInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .HasMany(e => e.T_EC_EnergyItemResult)
                .WithRequired(e => e.T_BD_BuildBaseInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .HasMany(e => e.T_BD_BuildGroupBaseInfo)
                .WithMany(e => e.T_BD_BuildBaseInfo)
                .Map(m => m.ToTable("T_BD_BuildGroupRelaInfo").MapLeftKey("F_BuildID").MapRightKey("F_BuildGroupID"));

            modelBuilder.Entity<T_BD_BuildEngyConsRenoInfo>()
                .Property(e => e.F_BuildID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildEngyConsRenoInfo>()
                .Property(e => e.F_RenoDept)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildEngyConsRenoInfo>()
                .Property(e => e.F_RenoDesc)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildExInfo>()
                .Property(e => e.F_BuildID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildExInfo>()
                .Property(e => e.F_OpenHours)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_BD_BuildExInfo>()
                .Property(e => e.F_ServiceLevel)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildExInfo>()
                .Property(e => e.F_HotelLiveRate)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_BD_BuildExInfo>()
                .Property(e => e.F_HospitalStandard)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildExInfo>()
                .Property(e => e.F_HospitalType)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildExInfo>()
                .Property(e => e.F_GroupFunc)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildExInfo>()
                .Property(e => e.F_ExtendFunc)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildExInfo>()
                .Property(e => e.F_ElectriPrice)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildExInfo>()
                .Property(e => e.F_WaterPrice)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildExInfo>()
                .Property(e => e.F_GasPrice)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildExInfo>()
                .Property(e => e.F_HeatPrice)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildExInfo>()
                .Property(e => e.F_OtherPrice)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildGroupBaseInfo>()
                .Property(e => e.F_BuildGroupID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildGroupBaseInfo>()
                .Property(e => e.F_BuildGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildGroupBaseInfo>()
                .Property(e => e.F_GroupAliasName)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildGroupBaseInfo>()
                .Property(e => e.F_GroupDesc)
                .IsUnicode(false);

            modelBuilder.Entity<T_DC_CityTempInfo>()
                .Property(e => e.F_DataCenterID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_DC_CityTempInfo>()
                .Property(e => e.F_DistrictCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_DC_CityTempInfo>()
                .Property(e => e.F_TempValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_DC_DataCenterBaseInfo>()
                .Property(e => e.F_DataCenterID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_DC_DataCenterBaseInfo>()
                .Property(e => e.F_DataCenterName)
                .IsUnicode(false);

            modelBuilder.Entity<T_DC_DataCenterBaseInfo>()
                .Property(e => e.F_DataCenterManager)
                .IsUnicode(false);

            modelBuilder.Entity<T_DC_DataCenterBaseInfo>()
                .Property(e => e.F_DataCenterDesc)
                .IsUnicode(false);

            modelBuilder.Entity<T_DC_DataCenterBaseInfo>()
                .Property(e => e.F_DataCenterContact)
                .IsUnicode(false);

            modelBuilder.Entity<T_DC_DataCenterBaseInfo>()
                .Property(e => e.F_DataCenterTel)
                .IsUnicode(false);

            modelBuilder.Entity<T_DC_DataCenterBaseInfo>()
                .HasMany(e => e.T_BD_BuildBaseInfo)
                .WithRequired(e => e.T_DC_DataCenterBaseInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_DC_DataCenterBaseInfo>()
                .HasMany(e => e.T_DC_CityTempInfo)
                .WithRequired(e => e.T_DC_DataCenterBaseInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_DT_EnergyItemDict>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_DT_EnergyItemDict>()
                .Property(e => e.F_EnergyItemName)
                .IsUnicode(false);

            modelBuilder.Entity<T_DT_EnergyItemDict>()
                .Property(e => e.F_ParentItemCode)
                .IsUnicode(false);

            modelBuilder.Entity<T_DT_EnergyItemDict>()
                .Property(e => e.F_EnergyItemType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_DT_EnergyItemDict>()
                .Property(e => e.F_EnergyItemUnit)
                .IsUnicode(false);

            modelBuilder.Entity<T_DT_EnergyItemDict>()
                .Property(e => e.F_EnergyItemFml)
                .IsUnicode(false);

            modelBuilder.Entity<T_DT_EnergyItemDict>()
                .HasMany(e => e.T_EC_EnergyItemDayResult)
                .WithRequired(e => e.T_DT_EnergyItemDict)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_DT_EnergyItemDict>()
                .HasMany(e => e.T_EC_EnergyItemHourResult)
                .WithRequired(e => e.T_DT_EnergyItemDict)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_DT_EnergyItemDict>()
                .HasMany(e => e.T_EC_EnergyItemResult)
                .WithRequired(e => e.T_DT_EnergyItemDict)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_DT_EnergyItemDict>()
                .HasMany(e => e.T_EC_RoomEnergyItemDayResult)
                .WithRequired(e => e.T_DT_EnergyItemDict)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_DT_EnergyItemDict>()
                .HasMany(e => e.T_EC_RoomEnergyItemHourResult)
                .WithRequired(e => e.T_DT_EnergyItemDict)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_DT_EnergyItemDict>()
                .HasMany(e => e.T_EC_RoomEnergyItemMonthResult)
                .WithRequired(e => e.T_DT_EnergyItemDict)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_DT_EnergyItemDict>()
                .HasMany(e => e.T_EC_RoomEnergyItemResult)
                .WithRequired(e => e.T_DT_EnergyItemDict)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_DT_EnergyItemDict>()
                .HasMany(e => e.T_EC_UnitEnergyItemDayResult)
                .WithRequired(e => e.T_DT_EnergyItemDict)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_DT_EnergyItemDict>()
                .HasMany(e => e.T_EC_UnitEnergyItemHourResult)
                .WithRequired(e => e.T_DT_EnergyItemDict)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_DT_EnergyItemDict>()
                .HasMany(e => e.T_EC_UnitEnergyItemResult)
                .WithRequired(e => e.T_DT_EnergyItemDict)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_EC_EnergyItemDayResult>()
                .Property(e => e.F_DayResultID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_EnergyItemDayResult>()
                .Property(e => e.F_BuildID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_EnergyItemDayResult>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_EnergyItemDayResult>()
                .Property(e => e.F_DayValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_EnergyItemDayResult>()
                .Property(e => e.F_DayEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_EnergyItemDayResult>()
                .Property(e => e.F_HourMaxValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_EnergyItemDayResult>()
                .Property(e => e.F_HourMaxEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_EnergyItemDayResult>()
                .Property(e => e.F_HourMinValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_EnergyItemDayResult>()
                .Property(e => e.F_HourMinEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_EnergyItemHourResult>()
                .Property(e => e.F_HourResultID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_EnergyItemHourResult>()
                .Property(e => e.F_BuildID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_EnergyItemHourResult>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_EnergyItemHourResult>()
                .Property(e => e.F_HourValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_EnergyItemHourResult>()
                .Property(e => e.F_HourEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_EnergyItemResult>()
                .Property(e => e.F_ResultID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_EnergyItemResult>()
                .Property(e => e.F_BuildID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_EnergyItemResult>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_EnergyItemResult>()
                .Property(e => e.F_Value)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_EnergyItemResult>()
                .Property(e => e.F_EquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_RoomEnergyItemDayResult>()
                .Property(e => e.F_DayResultID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_RoomEnergyItemDayResult>()
                .Property(e => e.F_RoomID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_RoomEnergyItemDayResult>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_RoomEnergyItemDayResult>()
                .Property(e => e.F_DayValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_RoomEnergyItemDayResult>()
                .Property(e => e.F_DayEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_RoomEnergyItemDayResult>()
                .Property(e => e.F_HourMaxValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_RoomEnergyItemDayResult>()
                .Property(e => e.F_HourMaxEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_RoomEnergyItemDayResult>()
                .Property(e => e.F_HourMinValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_RoomEnergyItemDayResult>()
                .Property(e => e.F_HourMinEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_RoomEnergyItemHourResult>()
                .Property(e => e.F_HourResultID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_RoomEnergyItemHourResult>()
                .Property(e => e.F_RoomID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_RoomEnergyItemHourResult>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_RoomEnergyItemHourResult>()
                .Property(e => e.F_HourValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_RoomEnergyItemHourResult>()
                .Property(e => e.F_HourEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_RoomEnergyItemMonthResult>()
                .Property(e => e.F_MonthResultID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_RoomEnergyItemMonthResult>()
                .Property(e => e.F_RoomID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_RoomEnergyItemMonthResult>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_RoomEnergyItemMonthResult>()
                .Property(e => e.F_MonthValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_RoomEnergyItemMonthResult>()
                .Property(e => e.F_MonthEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_RoomEnergyItemMonthResult>()
                .Property(e => e.F_HourMaxValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_RoomEnergyItemMonthResult>()
                .Property(e => e.F_HourMaxEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_RoomEnergyItemMonthResult>()
                .Property(e => e.F_HourMinValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_RoomEnergyItemMonthResult>()
                .Property(e => e.F_HourMinEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_RoomEnergyItemMonthResult>()
                .Property(e => e.F_DayMaxValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_RoomEnergyItemMonthResult>()
                .Property(e => e.F_DayMaxEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_RoomEnergyItemMonthResult>()
                .Property(e => e.F_DayMinValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_RoomEnergyItemMonthResult>()
                .Property(e => e.F_DayMinEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_RoomEnergyItemResult>()
                .Property(e => e.F_ResultID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_RoomEnergyItemResult>()
                .Property(e => e.F_RoomID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_RoomEnergyItemResult>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_RoomEnergyItemResult>()
                .Property(e => e.F_Value)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_RoomEnergyItemResult>()
                .Property(e => e.F_EquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_UnitEnergyItemDayResult>()
                .Property(e => e.F_DayResultID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_UnitEnergyItemDayResult>()
                .Property(e => e.F_UnitID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_UnitEnergyItemDayResult>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_UnitEnergyItemDayResult>()
                .Property(e => e.F_DayValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_UnitEnergyItemDayResult>()
                .Property(e => e.F_DayEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_UnitEnergyItemDayResult>()
                .Property(e => e.F_HourMaxValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_UnitEnergyItemDayResult>()
                .Property(e => e.F_HourMaxEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_UnitEnergyItemDayResult>()
                .Property(e => e.F_HourMinValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_UnitEnergyItemDayResult>()
                .Property(e => e.F_HourMinEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_UnitEnergyItemHourResult>()
                .Property(e => e.F_HourResultID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_UnitEnergyItemHourResult>()
                .Property(e => e.F_UnitID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_UnitEnergyItemHourResult>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_UnitEnergyItemHourResult>()
                .Property(e => e.F_HourValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_UnitEnergyItemHourResult>()
                .Property(e => e.F_HourEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_UnitEnergyItemResult>()
                .Property(e => e.F_ResultID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_UnitEnergyItemResult>()
                .Property(e => e.F_UnitID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_UnitEnergyItemResult>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_UnitEnergyItemResult>()
                .Property(e => e.F_Value)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_UnitEnergyItemResult>()
                .Property(e => e.F_EquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_RM_RoomInfo>()
                .Property(e => e.F_UnitID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_RM_RoomInfo>()
                .Property(e => e.F_BuildID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_RM_RoomInfo>()
                .Property(e => e.F_RoomID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_RM_RoomInfo>()
                .Property(e => e.F_RoomName)
                .IsUnicode(false);

            modelBuilder.Entity<T_RM_RoomInfo>()
                .Property(e => e.F_RoomArea)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_RM_RoomInfo>()
                .HasMany(e => e.T_EC_RoomEnergyItemDayResult)
                .WithRequired(e => e.T_RM_RoomInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_RM_RoomInfo>()
                .HasMany(e => e.T_EC_RoomEnergyItemHourResult)
                .WithRequired(e => e.T_RM_RoomInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_RM_RoomInfo>()
                .HasMany(e => e.T_EC_RoomEnergyItemMonthResult)
                .WithRequired(e => e.T_RM_RoomInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_RM_RoomInfo>()
                .HasMany(e => e.T_EC_RoomEnergyItemResult)
                .WithRequired(e => e.T_RM_RoomInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_ST_CircuitMeterInfo>()
                .Property(e => e.F_CircuitID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_CircuitMeterInfo>()
                .Property(e => e.F_BuildID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_CircuitMeterInfo>()
                .Property(e => e.F_ParentID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_CircuitMeterInfo>()
                .Property(e => e.F_MeterID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_CircuitMeterInfo>()
                .Property(e => e.F_CircuitName)
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_DataCollectionInfo>()
                .Property(e => e.F_CollectionID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_DataCollectionInfo>()
                .Property(e => e.F_BuildID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_DataCollectionInfo>()
                .Property(e => e.F_CollectionName)
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_DataCollectionInfo>()
                .Property(e => e.F_CollectionURL)
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_MeterParamInfo>()
                .Property(e => e.F_MeterParamID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_MeterParamInfo>()
                .Property(e => e.F_MeterProdID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_MeterParamInfo>()
                .Property(e => e.F_MeterParamName)
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_MeterParamInfo>()
                .Property(e => e.F_ChangeRate)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_ST_MeterParamInfo>()
                .Property(e => e.F_ValueType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_MeterProdInfo>()
                .Property(e => e.F_MeterProdID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_MeterProdInfo>()
                .Property(e => e.F_MeterProdName)
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_MeterProdInfo>()
                .Property(e => e.F_MaterType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_MeterProdInfo>()
                .Property(e => e.F_MeterProducer)
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_MeterProdInfo>()
                .Property(e => e.F_MaterModel)
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_MeterProdInfo>()
                .Property(e => e.F_MeterProdDesc)
                .IsUnicode(false);

            modelBuilder.Entity<T_UT_UnitBaseInfo>()
                .Property(e => e.F_UnitID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_UT_UnitBaseInfo>()
                .Property(e => e.F_UnitName)
                .IsUnicode(false);

            modelBuilder.Entity<T_UT_UnitBaseInfo>()
                .Property(e => e.F_AliasName)
                .IsUnicode(false);

            modelBuilder.Entity<T_UT_UnitBaseInfo>()
                .Property(e => e.F_TotalArea)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_UT_UnitBaseInfo>()
                .Property(e => e.F_AirArea)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_UT_UnitBaseInfo>()
                .Property(e => e.F_HeatArea)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_UT_UnitBaseInfo>()
                .Property(e => e.F_CreateUser)
                .IsUnicode(false);

            modelBuilder.Entity<T_UT_UnitBaseInfo>()
                .HasMany(e => e.T_EC_UnitEnergyItemDayResult)
                .WithRequired(e => e.T_UT_UnitBaseInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_UT_UnitBaseInfo>()
                .HasMany(e => e.T_EC_UnitEnergyItemHourResult)
                .WithRequired(e => e.T_UT_UnitBaseInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_UT_UnitBaseInfo>()
                .HasMany(e => e.T_EC_UnitEnergyItemResult)
                .WithRequired(e => e.T_UT_UnitBaseInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_OV_MeterOrigValue>()
                .Property(e => e.F_OrigValueID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_OV_MeterOrigValue>()
                .Property(e => e.F_BuildID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_OV_MeterOrigValue>()
                .Property(e => e.F_MeterID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_OV_MeterOrigValue>()
                .Property(e => e.F_MeterParamID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_OV_MeterOrigValue>()
                .Property(e => e.F_OrigValue)
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_MeterUseInfo>()
                .Property(e => e.F_MeterID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_MeterUseInfo>()
                .Property(e => e.F_BuildID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_MeterUseInfo>()
                .Property(e => e.F_MeterName)
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_MeterUseInfo>()
                .Property(e => e.F_MeterProdID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_MeterUseInfo>()
                .Property(e => e.F_CollectionID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_MeterUseInfo>()
                .Property(e => e.F_MeterAddr1)
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_MeterUseInfo>()
                .Property(e => e.F_MeterAddr2)
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_MeterUseInfo>()
                .Property(e => e.F_MeterAddr3)
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_MeterUseInfo>()
                .Property(e => e.F_Rate)
                .HasPrecision(18, 4);
        }
    }
}
