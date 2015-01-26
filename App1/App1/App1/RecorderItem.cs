using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    public class RecorderItem
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public decimal PurchaseUnitPrice { get; set; }
        public decimal PurchaseWeight { get; set; }
        public decimal PurchaseTotalPrice { get; set; }

        public decimal SellUnitPrice { get; set; }
        public decimal SellWeight { get; set; }
        public decimal SellTotalPrice { get; set; }
        public decimal Income { get; set; }

        public int State { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime HappenDate { get; set; }


    }
}
