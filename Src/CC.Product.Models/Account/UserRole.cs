using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackMamba.Framework.SubSonic;

namespace CC.Product.Models.Account
{
   public class UserRole:EntityBase
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        //public virtual User User { get; set; }
        //public virtual Role Role { get; set; }
    }
}
