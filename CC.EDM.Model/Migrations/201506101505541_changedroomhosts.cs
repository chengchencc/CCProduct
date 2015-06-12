namespace CC.EDM.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedroomhosts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        BuildingArea = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FloorCount = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        Area = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Building_Id = c.Int(nullable: false),
                        Institute_Id = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        UnitPrice_Id = c.Int(),
                        EnergyType_F_EnergyItemCode = c.String(maxLength: 5),
                        RoomHosts_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buildings", t => t.Building_Id, cascadeDelete: true)
                .ForeignKey("dbo.Institutes", t => t.Institute_Id, cascadeDelete: true)
                .ForeignKey("dbo.UnitPrices", t => t.UnitPrice_Id)
                .ForeignKey("dbo.EnergyTypes", t => t.EnergyType_F_EnergyItemCode)
                .ForeignKey("dbo.RoomHosts", t => t.RoomHosts_Id)
                .Index(t => t.Building_Id)
                .Index(t => t.Institute_Id)
                .Index(t => t.UnitPrice_Id)
                .Index(t => t.EnergyType_F_EnergyItemCode)
                .Index(t => t.RoomHosts_Id);
            
            CreateTable(
                "dbo.Institutes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        PeopleCount = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UnitPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Water = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Electricity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Coal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Gas = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Steam = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comdicts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Key = c.String(),
                        Value = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EnergyItemDayResults",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        EnergyValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EnergyUnit = c.String(),
                        EnergyDeviceCode = c.String(),
                        EnergyType_F_EnergyItemCode = c.String(maxLength: 5),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EnergyTypes", t => t.EnergyType_F_EnergyItemCode)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.StartDate)
                .Index(t => t.EndDate)
                .Index(t => t.EnergyType_F_EnergyItemCode)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.EnergyTypes",
                c => new
                    {
                        F_EnergyItemCode = c.String(nullable: false, maxLength: 5),
                        F_EnergyItemName = c.String(nullable: false, maxLength: 32),
                        F_ParentItemCode = c.String(maxLength: 16),
                        F_EnergyItemType = c.String(nullable: false, maxLength: 1),
                        F_EnergyItemUnit = c.String(nullable: false, maxLength: 16),
                        F_EnergyItemFml = c.String(nullable: false, maxLength: 16),
                        F_EnergyItemState = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.F_EnergyItemCode);
            
            CreateTable(
                "dbo.EnergyItemHourResults",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        EnergyValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EnergyUnit = c.String(),
                        EnergyDeviceCode = c.String(),
                        EnergyType_F_EnergyItemCode = c.String(maxLength: 5),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EnergyTypes", t => t.EnergyType_F_EnergyItemCode)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.StartDate)
                .Index(t => t.EndDate)
                .Index(t => t.EnergyType_F_EnergyItemCode)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.EnergyItemMonthResults",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        EnergyValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EnergyUnit = c.String(),
                        EnergyDeviceCode = c.String(),
                        EnergyType_F_EnergyItemCode = c.String(maxLength: 5),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EnergyTypes", t => t.EnergyType_F_EnergyItemCode)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.StartDate)
                .Index(t => t.EndDate)
                .Index(t => t.EnergyType_F_EnergyItemCode)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.EnergyItemResults",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        EnergyValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EnergyUnit = c.String(),
                        EnergyDeviceCode = c.String(),
                        EnergyType_F_EnergyItemCode = c.String(maxLength: 5),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EnergyTypes", t => t.EnergyType_F_EnergyItemCode)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.StartDate)
                .Index(t => t.EndDate)
                .Index(t => t.EnergyType_F_EnergyItemCode)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.EnergyPorts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Port = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Energy_F_EnergyItemCode = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EnergyTypes", t => t.Energy_F_EnergyItemCode)
                .Index(t => t.Energy_F_EnergyItemCode);
            
            CreateTable(
                "dbo.RoomHosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hosts = c.String(),
                        Port = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        EnergyType_F_EnergyItemCode = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EnergyTypes", t => t.EnergyType_F_EnergyItemCode)
                .Index(t => t.EnergyType_F_EnergyItemCode);
            
            CreateTable(
                "dbo.SyncDataLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SyncItemId = c.String(),
                        SyncType = c.Int(nullable: false),
                        SyncError = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "RoomHosts_Id", "dbo.RoomHosts");
            DropForeignKey("dbo.RoomHosts", "EnergyType_F_EnergyItemCode", "dbo.EnergyTypes");
            DropForeignKey("dbo.EnergyPorts", "Energy_F_EnergyItemCode", "dbo.EnergyTypes");
            DropForeignKey("dbo.EnergyItemResults", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.EnergyItemResults", "EnergyType_F_EnergyItemCode", "dbo.EnergyTypes");
            DropForeignKey("dbo.EnergyItemMonthResults", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.EnergyItemMonthResults", "EnergyType_F_EnergyItemCode", "dbo.EnergyTypes");
            DropForeignKey("dbo.EnergyItemHourResults", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.EnergyItemHourResults", "EnergyType_F_EnergyItemCode", "dbo.EnergyTypes");
            DropForeignKey("dbo.EnergyItemDayResults", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.EnergyItemDayResults", "EnergyType_F_EnergyItemCode", "dbo.EnergyTypes");
            DropForeignKey("dbo.Rooms", "EnergyType_F_EnergyItemCode", "dbo.EnergyTypes");
            DropForeignKey("dbo.Rooms", "UnitPrice_Id", "dbo.UnitPrices");
            DropForeignKey("dbo.Rooms", "Institute_Id", "dbo.Institutes");
            DropForeignKey("dbo.Rooms", "Building_Id", "dbo.Buildings");
            DropIndex("dbo.RoomHosts", new[] { "EnergyType_F_EnergyItemCode" });
            DropIndex("dbo.EnergyPorts", new[] { "Energy_F_EnergyItemCode" });
            DropIndex("dbo.EnergyItemResults", new[] { "Room_Id" });
            DropIndex("dbo.EnergyItemResults", new[] { "EnergyType_F_EnergyItemCode" });
            DropIndex("dbo.EnergyItemResults", new[] { "EndDate" });
            DropIndex("dbo.EnergyItemResults", new[] { "StartDate" });
            DropIndex("dbo.EnergyItemMonthResults", new[] { "Room_Id" });
            DropIndex("dbo.EnergyItemMonthResults", new[] { "EnergyType_F_EnergyItemCode" });
            DropIndex("dbo.EnergyItemMonthResults", new[] { "EndDate" });
            DropIndex("dbo.EnergyItemMonthResults", new[] { "StartDate" });
            DropIndex("dbo.EnergyItemHourResults", new[] { "Room_Id" });
            DropIndex("dbo.EnergyItemHourResults", new[] { "EnergyType_F_EnergyItemCode" });
            DropIndex("dbo.EnergyItemHourResults", new[] { "EndDate" });
            DropIndex("dbo.EnergyItemHourResults", new[] { "StartDate" });
            DropIndex("dbo.EnergyItemDayResults", new[] { "Room_Id" });
            DropIndex("dbo.EnergyItemDayResults", new[] { "EnergyType_F_EnergyItemCode" });
            DropIndex("dbo.EnergyItemDayResults", new[] { "EndDate" });
            DropIndex("dbo.EnergyItemDayResults", new[] { "StartDate" });
            DropIndex("dbo.Rooms", new[] { "RoomHosts_Id" });
            DropIndex("dbo.Rooms", new[] { "EnergyType_F_EnergyItemCode" });
            DropIndex("dbo.Rooms", new[] { "UnitPrice_Id" });
            DropIndex("dbo.Rooms", new[] { "Institute_Id" });
            DropIndex("dbo.Rooms", new[] { "Building_Id" });
            DropTable("dbo.SyncDataLogs");
            DropTable("dbo.RoomHosts");
            DropTable("dbo.EnergyPorts");
            DropTable("dbo.EnergyItemResults");
            DropTable("dbo.EnergyItemMonthResults");
            DropTable("dbo.EnergyItemHourResults");
            DropTable("dbo.EnergyTypes");
            DropTable("dbo.EnergyItemDayResults");
            DropTable("dbo.Comdicts");
            DropTable("dbo.UnitPrices");
            DropTable("dbo.Institutes");
            DropTable("dbo.Rooms");
            DropTable("dbo.Buildings");
        }
    }
}
