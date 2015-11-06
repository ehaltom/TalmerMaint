using System;
using System.Collections.Generic;
using TalmerMaint.Domain.Concrete;
using TalmerMaint.Domain.Entities;

namespace TalmerMaint.Domain.Abstract
{
    public interface ILocationRepository
    {
        IEnumerable<Location> Locations { get; }

        void SaveLocation(Location loc, bool addImg);

        Location DeleteLocation(int id);

        IEnumerable<LocServices> LocServicesByLocId(int id);
        IEnumerable<LocPhoneNums> LocPhoneNumsByLocId(int id);
        IEnumerable<LocHourCats> LocHoursByLocId(int id);
    }
}
