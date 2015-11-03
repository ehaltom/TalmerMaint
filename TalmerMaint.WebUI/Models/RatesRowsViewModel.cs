using System.Collections.Generic;
using System.Web.Mvc;
using TalmerMaint.Domain.Entities;


namespace TalmerMaint.WebUI.Models
{
    public class RatesRowsViewModel
    {
        public IEnumerable<RateTitle> Titles { get; set; }
        public RateRow RateRow { get; set; }
    }
}