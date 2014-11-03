using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Product.Models.Account;

namespace CC.Product.Data.Contexts
{
    public class LocalDBContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<LoginLog> LoginLogs { get; set; }
        public LocalDBContext()
            : base("name=LocalDB")
        {
            this.Configuration.LazyLoadingEnabled = true;

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Lodging>().Property(s => s.Owner).IsRequired();
            //modelBuilder.Entity<Destination>().HasMany(e => e.Lodgings).WithOptional().WillCascadeOnDelete(true);
            //modelBuilder.Configurations.Add(new DestinationConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {

                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

    }
}
