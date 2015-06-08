namespace EDMWebsite.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using CC.EDM.Model.Migrations;

    [System.Data.Entity.DbConfigurationType(typeof(MySqlConfiguration))]
    public partial class DeviceDbContext : DbContext
    {
        static DeviceDbContext()
        {
            Database.SetInitializer(new MySqlInitializer<DeviceDbContext>("edm2db"));
           // Database.SetInitializer(new CreateAndMigrateDatabaseInitializer<DeviceDbContext, MysqlConfiguration>());
        }

        public DeviceDbContext()
            : base("name=DeviceDbContext")
        {

        }



        public virtual DbSet<tb_data> tb_data { get; set; }
        public virtual DbSet<tb_date_t> tb_date_t { get; set; }
        public virtual DbSet<tb_device> tb_device { get; set; }
        public virtual DbSet<tb_devicealarm> tb_devicealarm { get; set; }
        public virtual DbSet<tb_devicecontrol> tb_devicecontrol { get; set; }
        public virtual DbSet<tb_deviceoutput> tb_deviceoutput { get; set; }
        public virtual DbSet<tb_layer> tb_layer { get; set; }
        public virtual DbSet<tb_layer2> tb_layer2 { get; set; }
        public virtual DbSet<tb_menu> tb_menu { get; set; }
        public virtual DbSet<tb_menu1> tb_menu1 { get; set; }
        public virtual DbSet<tb_proname> tb_proname { get; set; }
        public virtual DbSet<tb_user> tb_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_data>()
                .Property(e => e.macip)
                .IsUnicode(false);

            modelBuilder.Entity<tb_data>()
                .Property(e => e.port)
                .IsUnicode(false);

            modelBuilder.Entity<tb_data>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<tb_date_t>()
                .Property(e => e.macip)
                .IsUnicode(false);

            modelBuilder.Entity<tb_date_t>()
                .Property(e => e.command)
                .IsUnicode(false);

            modelBuilder.Entity<tb_date_t>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<tb_device>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<tb_device>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<tb_device>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<tb_device>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<tb_devicealarm>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_devicealarm>()
                .Property(e => e.condition)
                .IsUnicode(false);

            modelBuilder.Entity<tb_devicealarm>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<tb_devicecontrol>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_devicecontrol>()
                .Property(e => e.command)
                .IsUnicode(false);

            modelBuilder.Entity<tb_devicecontrol>()
                .Property(e => e.port)
                .IsUnicode(false);

            modelBuilder.Entity<tb_devicecontrol>()
                .Property(e => e.macip)
                .IsUnicode(false);

            modelBuilder.Entity<tb_devicecontrol>()
                .Property(e => e.action)
                .IsUnicode(false);

            modelBuilder.Entity<tb_deviceoutput>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_deviceoutput>()
                .Property(e => e.port)
                .IsUnicode(false);

            modelBuilder.Entity<tb_deviceoutput>()
                .Property(e => e.macip)
                .IsUnicode(false);

            modelBuilder.Entity<tb_deviceoutput>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<tb_deviceoutput>()
                .Property(e => e.formula)
                .IsUnicode(false);

            modelBuilder.Entity<tb_layer>()
                .Property(e => e.imgurl)
                .IsUnicode(false);

            modelBuilder.Entity<tb_layer2>()
                .Property(e => e.xzb)
                .IsUnicode(false);

            modelBuilder.Entity<tb_layer2>()
                .Property(e => e.yzb)
                .IsUnicode(false);

            modelBuilder.Entity<tb_menu>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_menu1>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_menu1>()
                .Property(e => e.remark)
                .IsUnicode(false);

            modelBuilder.Entity<tb_menu1>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<tb_proname>()
                .Property(e => e.proname)
                .IsUnicode(false);

            modelBuilder.Entity<tb_proname>()
                .Property(e => e.prouser)
                .IsUnicode(false);

            modelBuilder.Entity<tb_user>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<tb_user>()
                .Property(e => e.power)
                .IsUnicode(false);
        }
    }
}
