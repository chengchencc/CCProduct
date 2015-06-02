using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
