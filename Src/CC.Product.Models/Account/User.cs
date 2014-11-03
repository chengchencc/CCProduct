using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubSonic.SqlGeneration.Schema;
using BlackMamba.Framework.SubSonic;
namespace CC.Product.Models.Account
{
    public class User : EntityBase
    {
        [Required]
        [Display(Name = "User No")]
        public string No { get; set; }

        [Required]
        [StringLength(20)]
        [SubSonicStringLength(20)]
        [Display(Name = "User Name")]
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置 用户昵称
        /// </summary>
        [Required]
        [StringLength(20)]
        [SubSonicStringLength(20)]
        [SubSonicNullString]
        public string NickName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-Mail")]
        [SubSonicNullString]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [SubSonicNullString]
        public string PhoneNumber { get; set; }
        [SubSonicNullString]
        public string Discription { get; set; }
        public DateTime? LockedTime { get; set; }
        [SubSonicNullString]
        public string LinkedNo { get; set; }
        public LinkedType LinkedType { get; set; }

        public bool RememberMe { get; set; }

        //public virtual List<Role> Roles { get; set; }

        /// <summary>
        /// 获取或设置 用户登录记录集合
        /// </summary>
        //public virtual List<LoginLog> LoginLogs { get; set; }

    }


}
