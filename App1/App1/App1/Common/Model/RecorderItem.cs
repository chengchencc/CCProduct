using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace App1.Common.Model
{
    class RecorderItem
    {
        public int RecorderId { get; set; }
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal PurchaseUnitPrice { get; set; }
        public decimal PurchaseWeight { get; set; }
        public decimal PurchaseTotalPrice { get; set; }

        public decimal SellUnitPrice { get; set; }
        public decimal SellWeight { get; set; }
        public decimal SellTotalPrice { get; set; }

        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime HappenDate { get; set; }
    }
}
