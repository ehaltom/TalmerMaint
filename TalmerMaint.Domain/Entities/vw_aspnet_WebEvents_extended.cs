namespace TalmerMaint.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_aspnet_WebEvents_extended
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(32)]
        public string EventId { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime EventTimeUtc { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime EventTime { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(256)]
        public string EventType { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal EventSequence { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal EventOccurrence { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EventCode { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EventDetailCode { get; set; }

        [StringLength(1024)]
        public string Message { get; set; }

        [StringLength(256)]
        public string ApplicationPath { get; set; }

        [StringLength(256)]
        public string ApplicationVirtualPath { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(256)]
        public string MachineName { get; set; }

        [StringLength(1024)]
        public string RequestUrl { get; set; }

        [StringLength(256)]
        public string ExceptionType { get; set; }

        [Column(TypeName = "ntext")]
        public string Details { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(10)]
        public string Level { get; set; }
    }
}
