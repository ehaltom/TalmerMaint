using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TalmerMaint.Domain.Abstract;
using TalmerMaint.Domain.Entities;

namespace TalmerMaint.Domain.Concrete
{
    public class EFDbChangeLog : IDbChangeLog
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<DbChangeLog> ChangeLogs { get{ return context.DbChangeLogs.ToList(); } }

        
    }
}
