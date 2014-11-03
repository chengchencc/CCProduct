using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackMamba.Framework.SubSonic;

namespace CC.Product.Models.Account
{
    public class LoginLog:EntityBase
    {

        /// <summary>
        /// 获取或设置 登录IP地址
        /// </summary>
        [Required]
        [StringLength(15)]
        public string IpAddress { get; set; }

        /// <summary>
        /// 获取或设置 用户信息
        /// </summary>
        public string UserId { get; set; }
        //public virtual User User { get; set; }
    }
}
