namespace TalmerMaint.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NLog_Error
    {
        public int Id { get; set; }

        public DateTime time_stamp { get; set; }

        [Required]
        public string host { get; set; }

        [Required]
        [StringLength(150)]
        public string type { get; set; }

        [Required]
        [StringLength(150)]
        public string source { get; set; }

        [Required]
        public string message { get; set; }

        [Required]
        [StringLength(150)]
        public string level { get; set; }

        [Required]
        [StringLength(150)]
        public string logger { get; set; }

        public string changes { get; set; }

        [Required]
        public string stacktrace { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string allxml { get; set; }
    }
}
