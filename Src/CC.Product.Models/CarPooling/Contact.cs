using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Product.Models.CarPooling
{
    public class Contact
    {
        public int Id { get; set; }
        public ContactType Type { get; set; }
        public string Value { get; set; }
        public bool IsValidated { get; set; }
    }
    public enum ContactType
    {
        Phone,
        QQ,
        WeChart,
        WangWang,
        Email
    }
}