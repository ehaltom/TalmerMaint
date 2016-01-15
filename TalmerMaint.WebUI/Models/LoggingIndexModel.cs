using System.Collections.Generic;
using TalmerMaint.Domain.Entities;

namespace TalmerMaint.WebUI.Models
{
    public class LoggingIndexModel
    {
        public IEnumerable<LogEvent> LogEvents { get; set; }

        public string LoggerProviderName { get; set; }
        public string LogLevel { get; set; }
        public string Period { get; set; }


        public PagingInfo PagingInfo { get; set; }

       
    }
}