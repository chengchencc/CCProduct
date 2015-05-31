namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_COM_Device
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(10)]
        public string TypeCode { get; set; }

        [StringLength(50)]
        public string TypeName { get; set; }

        [StringLength(10)]
        public string DistrictCode { get; set; }

        [StringLength(50)]
        public string DistrictName { get; set; }

        [StringLength(11)]
        public string BuildCode { get; set; }

        [StringLength(20)]
        public string BuildName { get; set; }

        [StringLength(5)]
        public string RoomCode { get; set; }

        [StringLength(50)]
        public string RoomName { get; set; }

        [StringLength(10)]
        public string SystemID { get; set; }

        [StringLength(50)]
        public string SystemName { get; set; }

        [StringLength(5)]
        public string EID { get; set; }

        [StringLength(5)]
        public string meterReadingType { get; set; }

        [StringLength(50)]
        public string meterReadingTypeName { get; set; }

        [StringLength(5)]
        public string meterProperty { get; set; }

        [StringLength(10)]
        public string meterPropertyName { get; set; }

        [StringLength(50)]
        public string meterRange { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        public DateTime? InstallTime { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(50)]
        public string Factory { get; set; }

        public decimal? transformationRatio { get; set; }

        public decimal? hourThreshold { get; set; }

        public decimal? dayThreshold { get; set; }

        public decimal? monthThreshold { get; set; }

        public decimal? pipeDaimeter { get; set; }
    }
}
