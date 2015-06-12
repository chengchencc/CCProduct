namespace CC.EDM.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRoomModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "RoomHosts_Id", "dbo.RoomHosts");
            DropIndex("dbo.Rooms", new[] { "RoomHosts_Id" });
            CreateTable(
                "dbo.RoomHostsRooms",
                c => new
                    {
                        RoomHosts_Id = c.Int(nullable: false),
                        Room_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoomHosts_Id, t.Room_Id })
                .ForeignKey("dbo.RoomHosts", t => t.RoomHosts_Id, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.Room_Id, cascadeDelete: true)
                .Index(t => t.RoomHosts_Id)
                .Index(t => t.Room_Id);
            
            DropColumn("dbo.Rooms", "RoomHosts_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "RoomHosts_Id", c => c.Int());
            DropForeignKey("dbo.RoomHostsRooms", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.RoomHostsRooms", "RoomHosts_Id", "dbo.RoomHosts");
            DropIndex("dbo.RoomHostsRooms", new[] { "Room_Id" });
            DropIndex("dbo.RoomHostsRooms", new[] { "RoomHosts_Id" });
            DropTable("dbo.RoomHostsRooms");
            CreateIndex("dbo.Rooms", "RoomHosts_Id");
            AddForeignKey("dbo.Rooms", "RoomHosts_Id", "dbo.RoomHosts", "Id");
        }
    }
}
