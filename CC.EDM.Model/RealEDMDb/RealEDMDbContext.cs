namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RealEDMDbContext : DbContext
    {
        public RealEDMDbContext()
            : base("name=RealEDMDbContext")
        {
        }

        public virtual DbSet<EngryConfigInit> EngryConfigInits { get; set; }
        public virtual DbSet<G_DICTIONARY_T> G_DICTIONARY_T { get; set; }
        public virtual DbSet<G_DUCTNET_T> G_DUCTNET_T { get; set; }
        public virtual DbSet<G_FLYPOINT_T> G_FLYPOINT_T { get; set; }
        public virtual DbSet<G_FLYROAD_T> G_FLYROAD_T { get; set; }
        public virtual DbSet<G_VALVE_T> G_VALVE_T { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<T_BD_BuildAddFile> T_BD_BuildAddFile { get; set; }
        public virtual DbSet<T_BD_BuildBaseInfo> T_BD_BuildBaseInfo { get; set; }
        public virtual DbSet<T_BD_BuildEngyConsRenoInfo> T_BD_BuildEngyConsRenoInfo { get; set; }
        public virtual DbSet<T_BD_BuildExInfo> T_BD_BuildExInfo { get; set; }
        public virtual DbSet<T_BD_BuildGroupBaseInfo> T_BD_BuildGroupBaseInfo { get; set; }
        public virtual DbSet<T_COM_About> T_COM_About { get; set; }
        public virtual DbSet<T_COM_Admin> T_COM_Admin { get; set; }
        public virtual DbSet<T_COM_AdminLog> T_COM_AdminLog { get; set; }
        public virtual DbSet<T_COM_AdminMenu> T_COM_AdminMenu { get; set; }
        public virtual DbSet<T_COM_AdminRole> T_COM_AdminRole { get; set; }
        public virtual DbSet<T_COM_Device> T_COM_Device { get; set; }
        public virtual DbSet<T_COM_News> T_COM_News { get; set; }
        public virtual DbSet<T_COM_PosMap> T_COM_PosMap { get; set; }
        public virtual DbSet<T_COM_PriceList> T_COM_PriceList { get; set; }
        public virtual DbSet<T_COM_School> T_COM_School { get; set; }
        public virtual DbSet<T_COM_UnitZhiBiao> T_COM_UnitZhiBiao { get; set; }
        public virtual DbSet<T_COM_Zhibiao> T_COM_Zhibiao { get; set; }
        public virtual DbSet<T_DC_CityTempInfo> T_DC_CityTempInfo { get; set; }
        public virtual DbSet<T_DC_DataCenterBaseInfo> T_DC_DataCenterBaseInfo { get; set; }
        public virtual DbSet<T_DC_DataCenterUploadLog> T_DC_DataCenterUploadLog { get; set; }
        public virtual DbSet<T_DC_UploadCenterBaseInfo> T_DC_UploadCenterBaseInfo { get; set; }
        public virtual DbSet<T_DT_EnergyItemDict> T_DT_EnergyItemDict { get; set; }
        public virtual DbSet<T_DT_EnergyItemDict_tree> T_DT_EnergyItemDict_tree { get; set; }
        public virtual DbSet<T_EC_EnergyItemDayResult> T_EC_EnergyItemDayResult { get; set; }
        public virtual DbSet<T_EC_EnergyItemHourResult> T_EC_EnergyItemHourResult { get; set; }
        public virtual DbSet<T_EC_EnergyItemMonthResult> T_EC_EnergyItemMonthResult { get; set; }
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
        public virtual DbSet<warn> warns { get; set; }
        public virtual DbSet<warnRule> warnRules { get; set; }
        public virtual DbSet<BuildTypeInit> BuildTypeInits { get; set; }
        public virtual DbSet<T_BD_AlarmSet> T_BD_AlarmSet { get; set; }
        public virtual DbSet<T_COM_AdminRolePriv> T_COM_AdminRolePriv { get; set; }
        public virtual DbSet<T_EC_CircuitEnergyItemDayResult> T_EC_CircuitEnergyItemDayResult { get; set; }
        public virtual DbSet<T_EC_CircuitEnergyItemHourResult> T_EC_CircuitEnergyItemHourResult { get; set; }
        public virtual DbSet<T_EC_CircuitEnergyItemMonthResult> T_EC_CircuitEnergyItemMonthResult { get; set; }
        public virtual DbSet<T_EC_CircuitEnergyItemResult> T_EC_CircuitEnergyItemResult { get; set; }
        public virtual DbSet<T_EC_CircuitEnergyItemResultReal> T_EC_CircuitEnergyItemResultReal { get; set; }
        public virtual DbSet<T_EC_EnergyItemReal> T_EC_EnergyItemReal { get; set; }
        public virtual DbSet<T_EC_EnergyItemREAL_other> T_EC_EnergyItemREAL_other { get; set; }
        public virtual DbSet<T_EC_EnergyItemResult_Other> T_EC_EnergyItemResult_Other { get; set; }
        public virtual DbSet<T_EC_UnitEnergyItemMonthResult> T_EC_UnitEnergyItemMonthResult { get; set; }
        public virtual DbSet<T_OV_MeterOrigValue> T_OV_MeterOrigValue { get; set; }
        public virtual DbSet<T_ST_CircuitBaseInfo> T_ST_CircuitBaseInfo { get; set; }
        public virtual DbSet<T_ST_MeterUseInfo> T_ST_MeterUseInfo { get; set; }
        public virtual DbSet<T_US_UserInfo> T_US_UserInfo { get; set; }
        public virtual DbSet<testtable> testtables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EngryConfigInit>()
                .Property(e => e.FBuildID)
                .IsUnicode(false);

            modelBuilder.Entity<EngryConfigInit>()
                .Property(e => e.tjlx)
                .IsUnicode(false);

            modelBuilder.Entity<EngryConfigInit>()
                .Property(e => e.nhdm)
                .IsUnicode(false);

            modelBuilder.Entity<EngryConfigInit>()
                .Property(e => e.tjmd)
                .IsUnicode(false);

            modelBuilder.Entity<EngryConfigInit>()
                .Property(e => e.xsfs)
                .IsUnicode(false);

            modelBuilder.Entity<EngryConfigInit>()
                .Property(e => e.xsfsxx)
                .IsUnicode(false);

            modelBuilder.Entity<G_DICTIONARY_T>()
                .Property(e => e.TABLENAME)
                .IsUnicode(false);

            modelBuilder.Entity<G_DICTIONARY_T>()
                .Property(e => e.COLUMNNAME)
                .IsUnicode(false);

            modelBuilder.Entity<G_DICTIONARY_T>()
                .Property(e => e.ANOTHERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<G_DUCTNET_T>()
                .Property(e => e.GCODE)
                .IsUnicode(false);

            modelBuilder.Entity<G_DUCTNET_T>()
                .Property(e => e.GTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<G_DUCTNET_T>()
                .Property(e => e.PURPOSE)
                .IsUnicode(false);

            modelBuilder.Entity<G_DUCTNET_T>()
                .Property(e => e.STARTPOSITION)
                .IsUnicode(false);

            modelBuilder.Entity<G_DUCTNET_T>()
                .Property(e => e.ENDPOSITION)
                .IsUnicode(false);

            modelBuilder.Entity<G_DUCTNET_T>()
                .Property(e => e.DUCTLENGTH)
                .IsUnicode(false);

            modelBuilder.Entity<G_DUCTNET_T>()
                .Property(e => e.PIPEDIAMETER)
                .IsUnicode(false);

            modelBuilder.Entity<G_DUCTNET_T>()
                .Property(e => e.MATERIALQUALITY)
                .IsUnicode(false);

            modelBuilder.Entity<G_DUCTNET_T>()
                .Property(e => e.BUILDTIME)
                .IsUnicode(false);

            modelBuilder.Entity<G_DUCTNET_T>()
                .Property(e => e.PRINCIPAL)
                .IsUnicode(false);

            modelBuilder.Entity<G_DUCTNET_T>()
                .Property(e => e.IMAGNAME)
                .IsUnicode(false);

            modelBuilder.Entity<G_FLYROAD_T>()
                .HasMany(e => e.G_FLYPOINT_T)
                .WithOptional(e => e.G_FLYROAD_T)
                .WillCascadeOnDelete();

            modelBuilder.Entity<G_FLYROAD_T>()
                .HasOptional(e => e.G_FLYROAD_T1)
                .WithRequired(e => e.G_FLYROAD_T2);

            modelBuilder.Entity<G_VALVE_T>()
                .Property(e => e.GCODE)
                .IsUnicode(false);

            modelBuilder.Entity<G_VALVE_T>()
                .Property(e => e.GTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<G_VALVE_T>()
                .Property(e => e.POSITION)
                .IsUnicode(false);

            modelBuilder.Entity<G_VALVE_T>()
                .Property(e => e.LX)
                .IsUnicode(false);

            modelBuilder.Entity<G_VALVE_T>()
                .Property(e => e.GMODEL)
                .IsUnicode(false);

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
                .Property(e => e.F_BuildSubFunc)
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
                .HasMany(e => e.T_EC_RoomEnergyItemDayResult)
                .WithRequired(e => e.T_BD_BuildBaseInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .HasMany(e => e.T_EC_RoomEnergyItemResult)
                .WithRequired(e => e.T_BD_BuildBaseInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_BD_BuildBaseInfo>()
                .HasMany(e => e.T_RM_RoomInfo)
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

            modelBuilder.Entity<T_BD_BuildExInfo>()
                .Property(e => e.F_scienceType)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_BuildExInfo>()
                .Property(e => e.F_sitetype)
                .IsFixedLength();

            modelBuilder.Entity<T_BD_BuildExInfo>()
                .Property(e => e.F_DiningType)
                .IsFixedLength();

            modelBuilder.Entity<T_BD_BuildExInfo>()
                .Property(e => e.F_TestType)
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

            modelBuilder.Entity<T_COM_About>()
                .Property(e => e.style)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_About>()
                .Property(e => e.thumb)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_About>()
                .Property(e => e.linkurl)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_About>()
                .Property(e => e.template)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_About>()
                .Property(e => e.urlrule)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_About>()
                .Property(e => e.username)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_Admin>()
                .Property(e => e.username)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_Admin>()
                .Property(e => e.userpass)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_Admin>()
                .Property(e => e.lastloginip)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_Admin>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_AdminLog>()
                .Property(e => e.userip)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_AdminMenu>()
                .Property(e => e.menuname)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_AdminMenu>()
                .Property(e => e.linkurl)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_AdminMenu>()
                .Property(e => e.target)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_AdminMenu>()
                .Property(e => e.cname)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_AdminRole>()
                .Property(e => e.rolename)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_Device>()
                .Property(e => e.TypeCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_Device>()
                .Property(e => e.DistrictCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_Device>()
                .Property(e => e.BuildCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_Device>()
                .Property(e => e.RoomCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_Device>()
                .Property(e => e.SystemID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_Device>()
                .Property(e => e.EID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_Device>()
                .Property(e => e.meterReadingType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_Device>()
                .Property(e => e.meterProperty)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_Device>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_Device>()
                .Property(e => e.transformationRatio)
                .HasPrecision(8, 2);

            modelBuilder.Entity<T_COM_Device>()
                .Property(e => e.hourThreshold)
                .HasPrecision(8, 2);

            modelBuilder.Entity<T_COM_Device>()
                .Property(e => e.dayThreshold)
                .HasPrecision(8, 2);

            modelBuilder.Entity<T_COM_Device>()
                .Property(e => e.monthThreshold)
                .HasPrecision(8, 2);

            modelBuilder.Entity<T_COM_Device>()
                .Property(e => e.pipeDaimeter)
                .HasPrecision(8, 2);

            modelBuilder.Entity<T_COM_News>()
                .Property(e => e.style)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_News>()
                .Property(e => e.thumb)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_News>()
                .Property(e => e.linkurl)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_News>()
                .Property(e => e.readpoint)
                .HasPrecision(8, 2);

            modelBuilder.Entity<T_COM_News>()
                .Property(e => e.groupids_view)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_News>()
                .Property(e => e.template)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_News>()
                .Property(e => e.urlrule)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_News>()
                .Property(e => e.attachmentids)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_News>()
                .Property(e => e.newsids)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_PosMap>()
                .Property(e => e.sbid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_PosMap>()
                .Property(e => e.postype)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_PosMap>()
                .Property(e => e.sqlstr)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_PosMap>()
                .Property(e => e.sqlstr2)
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_PriceList>()
                .Property(e => e.Electrovalence)
                .HasPrecision(5, 2);

            modelBuilder.Entity<T_COM_PriceList>()
                .Property(e => e.WaterPrice)
                .HasPrecision(5, 2);

            modelBuilder.Entity<T_COM_PriceList>()
                .Property(e => e.GasPrice)
                .HasPrecision(5, 2);

            modelBuilder.Entity<T_COM_PriceList>()
                .Property(e => e.SteamPrice)
                .HasPrecision(5, 2);

            modelBuilder.Entity<T_COM_PriceList>()
                .Property(e => e.CoalPrice)
                .HasPrecision(5, 2);

            modelBuilder.Entity<T_COM_School>()
                .Property(e => e.Area)
                .HasPrecision(10, 2);

            modelBuilder.Entity<T_COM_School>()
                .Property(e => e.CoolArea)
                .HasPrecision(10, 2);

            modelBuilder.Entity<T_COM_School>()
                .Property(e => e.HotArea)
                .HasPrecision(10, 2);

            modelBuilder.Entity<T_COM_School>()
                .Property(e => e.ZIPCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_UnitZhiBiao>()
                .Property(e => e.goodvalue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_COM_UnitZhiBiao>()
                .Property(e => e.maxvalue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_COM_UnitZhiBiao>()
                .Property(e => e.unid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_UnitZhiBiao>()
                .Property(e => e.nhtype)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_Zhibiao>()
                .Property(e => e.AreaWator)
                .HasPrecision(10, 2);

            modelBuilder.Entity<T_COM_Zhibiao>()
                .Property(e => e.AreaDian)
                .HasPrecision(10, 2);

            modelBuilder.Entity<T_COM_Zhibiao>()
                .Property(e => e.AreaEqu)
                .HasPrecision(10, 2);

            modelBuilder.Entity<T_COM_Zhibiao>()
                .Property(e => e.AreaPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<T_COM_Zhibiao>()
                .Property(e => e.PeoWator)
                .HasPrecision(10, 2);

            modelBuilder.Entity<T_COM_Zhibiao>()
                .Property(e => e.PeoDian)
                .HasPrecision(10, 2);

            modelBuilder.Entity<T_COM_Zhibiao>()
                .Property(e => e.PeoEqu)
                .HasPrecision(10, 2);

            modelBuilder.Entity<T_COM_Zhibiao>()
                .Property(e => e.PeoPrice)
                .HasPrecision(10, 2);

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

            modelBuilder.Entity<T_DC_DataCenterUploadLog>()
                .Property(e => e.F_DataCenterID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_DC_DataCenterUploadLog>()
                .Property(e => e.F_DataCenterName)
                .IsUnicode(false);

            modelBuilder.Entity<T_DC_DataCenterUploadLog>()
                .Property(e => e.F_UploadDest)
                .IsUnicode(false);

            modelBuilder.Entity<T_DC_DataCenterUploadLog>()
                .Property(e => e.F_UploadFile)
                .IsUnicode(false);

            modelBuilder.Entity<T_DC_DataCenterUploadLog>()
                .Property(e => e.F_State)
                .IsUnicode(false);

            modelBuilder.Entity<T_DC_UploadCenterBaseInfo>()
                .Property(e => e.F_UploadCenterID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_DC_UploadCenterBaseInfo>()
                .Property(e => e.F_UploadCenterName)
                .IsUnicode(false);

            modelBuilder.Entity<T_DC_UploadCenterBaseInfo>()
                .Property(e => e.F_IP)
                .IsUnicode(false);

            modelBuilder.Entity<T_DC_UploadCenterBaseInfo>()
                .Property(e => e.F_Port)
                .IsUnicode(false);

            modelBuilder.Entity<T_DC_UploadCenterBaseInfo>()
                .Property(e => e.F_Inteval)
                .HasPrecision(8, 1);

            modelBuilder.Entity<T_DC_UploadCenterBaseInfo>()
                .Property(e => e.F_PWD)
                .IsUnicode(false);

            modelBuilder.Entity<T_DC_UploadCenterBaseInfo>()
                .Property(e => e.F_Starttime)
                .IsFixedLength();

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

            modelBuilder.Entity<T_DT_EnergyItemDict_tree>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_DT_EnergyItemDict_tree>()
                .Property(e => e.F_EnergyItemName)
                .IsUnicode(false);

            modelBuilder.Entity<T_DT_EnergyItemDict_tree>()
                .Property(e => e.F_ParentItemCode)
                .IsUnicode(false);

            modelBuilder.Entity<T_DT_EnergyItemDict_tree>()
                .Property(e => e.F_EnergyItemType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_DT_EnergyItemDict_tree>()
                .Property(e => e.F_EnergyItemUnit)
                .IsUnicode(false);

            modelBuilder.Entity<T_DT_EnergyItemDict_tree>()
                .Property(e => e.F_EnergyItemFml)
                .IsUnicode(false);

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

            modelBuilder.Entity<T_EC_EnergyItemMonthResult>()
                .Property(e => e.F_MonthResultID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_EnergyItemMonthResult>()
                .Property(e => e.F_BuildID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_EnergyItemMonthResult>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_EnergyItemMonthResult>()
                .Property(e => e.F_MonthValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_EnergyItemMonthResult>()
                .Property(e => e.F_MonthEquValue)
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
                .Property(e => e.F_BuildID)
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
                .Property(e => e.F_BuildID)
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
                .Property(e => e.F_BuildID)
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
                .Property(e => e.F_BuildID)
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

            modelBuilder.Entity<T_UT_UnitBaseInfo>()
                .HasMany(e => e.T_RM_RoomInfo)
                .WithRequired(e => e.T_UT_UnitBaseInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<warn>()
                .Property(e => e.F_buildID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<warn>()
                .Property(e => e.warnType)
                .IsUnicode(false);

            modelBuilder.Entity<warn>()
                .Property(e => e.remark)
                .IsUnicode(false);

            modelBuilder.Entity<warn>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<warnRule>()
                .Property(e => e.F_BuildID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<warnRule>()
                .Property(e => e.elec)
                .HasPrecision(18, 4);

            modelBuilder.Entity<warnRule>()
                .Property(e => e.water)
                .HasPrecision(18, 4);

            modelBuilder.Entity<warnRule>()
                .Property(e => e.heat)
                .HasPrecision(18, 4);

            modelBuilder.Entity<warnRule>()
                .Property(e => e.gas)
                .HasPrecision(18, 4);

            modelBuilder.Entity<BuildTypeInit>()
                .Property(e => e.typename)
                .IsUnicode(false);

            modelBuilder.Entity<BuildTypeInit>()
                .Property(e => e.contain)
                .IsUnicode(false);

            modelBuilder.Entity<T_BD_AlarmSet>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<T_BD_AlarmSet>()
                .Property(e => e.F_RoomID)
                .IsFixedLength();

            modelBuilder.Entity<T_COM_AdminRolePriv>()
                .Property(e => e.m)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_AdminRolePriv>()
                .Property(e => e.c)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_COM_AdminRolePriv>()
                .Property(e => e.a)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_CircuitEnergyItemDayResult>()
                .Property(e => e.F_DayResultID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_CircuitEnergyItemDayResult>()
                .Property(e => e.F_CircuitID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_CircuitEnergyItemDayResult>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_CircuitEnergyItemDayResult>()
                .Property(e => e.F_DayValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_CircuitEnergyItemDayResult>()
                .Property(e => e.F_DayEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_CircuitEnergyItemDayResult>()
                .Property(e => e.F_HourMaxValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_CircuitEnergyItemDayResult>()
                .Property(e => e.F_HourMaxEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_CircuitEnergyItemDayResult>()
                .Property(e => e.F_HourMinValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_CircuitEnergyItemDayResult>()
                .Property(e => e.F_HourMinEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_CircuitEnergyItemHourResult>()
                .Property(e => e.F_HourResultID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_CircuitEnergyItemHourResult>()
                .Property(e => e.F_CircuitID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_CircuitEnergyItemHourResult>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_CircuitEnergyItemHourResult>()
                .Property(e => e.F_HourValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_CircuitEnergyItemHourResult>()
                .Property(e => e.F_HourEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_CircuitEnergyItemMonthResult>()
                .Property(e => e.F_MonthResultID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_CircuitEnergyItemMonthResult>()
                .Property(e => e.F_CircuitID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_CircuitEnergyItemMonthResult>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_CircuitEnergyItemMonthResult>()
                .Property(e => e.F_MonthValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_CircuitEnergyItemMonthResult>()
                .Property(e => e.F_MonthEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_CircuitEnergyItemMonthResult>()
                .Property(e => e.F_HourMaxValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_CircuitEnergyItemMonthResult>()
                .Property(e => e.F_HourMaxEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_CircuitEnergyItemMonthResult>()
                .Property(e => e.F_HourMinValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_CircuitEnergyItemMonthResult>()
                .Property(e => e.F_HourMinEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_CircuitEnergyItemMonthResult>()
                .Property(e => e.F_DayMaxValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_CircuitEnergyItemMonthResult>()
                .Property(e => e.F_DayMaxEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_CircuitEnergyItemMonthResult>()
                .Property(e => e.F_DayMinValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_CircuitEnergyItemMonthResult>()
                .Property(e => e.F_DayMinEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_CircuitEnergyItemResult>()
                .Property(e => e.F_ResultID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_CircuitEnergyItemResult>()
                .Property(e => e.F_CircuitID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_CircuitEnergyItemResult>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_CircuitEnergyItemResult>()
                .Property(e => e.F_Value)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_CircuitEnergyItemResult>()
                .Property(e => e.F_EquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_CircuitEnergyItemResultReal>()
                .Property(e => e.F_ResultID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_CircuitEnergyItemResultReal>()
                .Property(e => e.F_CollectorName)
                .IsFixedLength();

            modelBuilder.Entity<T_EC_CircuitEnergyItemResultReal>()
                .Property(e => e.F_CircuitID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_CircuitEnergyItemResultReal>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_CircuitEnergyItemResultReal>()
                .Property(e => e.F_Value)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_CircuitEnergyItemResultReal>()
                .Property(e => e.F_EquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_EnergyItemReal>()
                .Property(e => e.F_ResultID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_EnergyItemReal>()
                .Property(e => e.F_CollectorName)
                .IsFixedLength();

            modelBuilder.Entity<T_EC_EnergyItemReal>()
                .Property(e => e.F_BuildID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_EnergyItemReal>()
                .Property(e => e.F_RoomID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_EnergyItemReal>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_EnergyItemReal>()
                .Property(e => e.F_Value)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_EnergyItemREAL_other>()
                .Property(e => e.F_BuildID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_EnergyItemREAL_other>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_EnergyItemREAL_other>()
                .Property(e => e.F_Value)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_EnergyItemREAL_other>()
                .Property(e => e.F_EquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_EnergyItemResult_Other>()
                .Property(e => e.F_ResultID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_EnergyItemResult_Other>()
                .Property(e => e.F_BuildID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_EnergyItemResult_Other>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_EnergyItemResult_Other>()
                .Property(e => e.F_Value)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_EnergyItemResult_Other>()
                .Property(e => e.F_EquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_UnitEnergyItemMonthResult>()
                .Property(e => e.F_MonthResultID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_UnitEnergyItemMonthResult>()
                .Property(e => e.F_UnitID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_UnitEnergyItemMonthResult>()
                .Property(e => e.F_EnergyItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_EC_UnitEnergyItemMonthResult>()
                .Property(e => e.F_MonthValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_UnitEnergyItemMonthResult>()
                .Property(e => e.F_MonthEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_UnitEnergyItemMonthResult>()
                .Property(e => e.F_HourMaxValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_UnitEnergyItemMonthResult>()
                .Property(e => e.F_HourMaxEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_UnitEnergyItemMonthResult>()
                .Property(e => e.F_HourMinValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_UnitEnergyItemMonthResult>()
                .Property(e => e.F_HourMinEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_UnitEnergyItemMonthResult>()
                .Property(e => e.F_DayMaxValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_UnitEnergyItemMonthResult>()
                .Property(e => e.F_DayMaxEquValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_UnitEnergyItemMonthResult>()
                .Property(e => e.F_DayMinValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<T_EC_UnitEnergyItemMonthResult>()
                .Property(e => e.F_DayMinEquValue)
                .HasPrecision(18, 4);

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

            modelBuilder.Entity<T_ST_CircuitBaseInfo>()
                .Property(e => e.F_CircuitID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_CircuitBaseInfo>()
                .Property(e => e.F_DistributeRoomID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_CircuitBaseInfo>()
                .Property(e => e.F_DistributeRoomName)
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_CircuitBaseInfo>()
                .Property(e => e.F_CircuitName)
                .IsUnicode(false);

            modelBuilder.Entity<T_ST_CircuitBaseInfo>()
                .Property(e => e.F_Type)
                .IsFixedLength()
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

            modelBuilder.Entity<T_US_UserInfo>()
                .Property(e => e.F_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<T_US_UserInfo>()
                .Property(e => e.F_Role)
                .IsUnicode(false);

            modelBuilder.Entity<T_US_UserInfo>()
                .Property(e => e.F_PWD)
                .IsUnicode(false);

            modelBuilder.Entity<testtable>()
                .Property(e => e.tt1)
                .IsFixedLength();

            modelBuilder.Entity<testtable>()
                .Property(e => e.tt2)
                .IsFixedLength();
        }
    }
}
