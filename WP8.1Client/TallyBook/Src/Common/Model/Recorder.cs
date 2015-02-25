using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    public class Recorder
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public decimal TotalExpenditure { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal Profit { get; set; }
        public int State { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime HappenDate { get; set; }


    }
}
