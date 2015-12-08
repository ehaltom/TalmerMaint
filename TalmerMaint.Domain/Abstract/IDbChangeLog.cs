using System;
using System.Collections.Generic;
using TalmerMaint.Domain.Entities;
using TalmerMaint.Domain.Concrete;

namespace TalmerMaint.Domain.Abstract
{
    public interface IDbChangeLog
    {
        IEnumerable<DbChangeLog> ChangeLogs { get; }
    }
}
