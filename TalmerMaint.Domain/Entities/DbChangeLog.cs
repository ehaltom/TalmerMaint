using System;
using System.ComponentModel.DataAnnotations;

namespace TalmerMaint.Domain.Entities
{
    public class DbChangeLog
    {

        public int Id { get; set; }

        [MaxLength(100)]
        public string UserName{ get; set; }

        [MaxLength(100)]
        public string Controller { get; set; }

        [MaxLength(100)]
        public string Action { get; set; }

        public int ItemId { get; set; }

        public string BeforeChange { get; set; }

        public string AfterChange { get; set; }

        
        public DateTime DateTime { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }

        public DbChangeLog()
        {
            DateTime = DateTime.Now;
        }
    }
}
