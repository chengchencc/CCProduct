using System;
using System.Collections.Generic;
using System.Linq;

namespace UwpDemo.Models.WayBook
{
    public class RealTimeBus
    {
        public string busId { get; set; }
        public double lng { get; set; }
        public double lat { get; set; }
        public float velocity { get; set; }
        public string isArrvLft { get; set; }
        public int stationSeqNum { get; set; }
        public string buslineId { get; set; }
        public DateTime actTime { get; set; }
        public string cardId { get; set; }
        public string orgName { get; set; }
        public bool isArriveDest { get; set; }
        public int dualSerialNum { get; set; }


    }
}