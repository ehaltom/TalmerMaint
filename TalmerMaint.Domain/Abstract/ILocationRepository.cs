using System;
using System.Collections.Generic;
using TalmerMaint.Domain.Entities;

namespace TalmerMaint.Domain.Abstract
{
    public interface ILocationRepository
    {
        IEnumerable<Location> Locations { get; }

        void SaveLocation(Location loc, bool addImg);

        Location DeleteLocation(int id);
    }
}
