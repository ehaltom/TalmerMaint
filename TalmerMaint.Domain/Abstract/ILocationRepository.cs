﻿using System;
using System.Collections.Generic;
using TalmerMaint.Domain.Concrete;
using TalmerMaint.Domain.Entities;

namespace TalmerMaint.Domain.Abstract
{
    public interface ILocationRepository
    {
        IEnumerable<Location> Locations { get; }
        IEnumerable<LocServices> LocServices{ get; }
        IEnumerable<LocImage> LocImages { get; }
        IEnumerable<LocHours> LocHours { get; }
        IEnumerable<LocHourCats> LocHourCats { get; }
        IEnumerable<LocPhoneNums> LocPhoneNums { get; }
        IEnumerable<LocPhoneExts> LocPhoneExts { get; }


        Location LocationByID(int id);
        LocImage ImageByLocationID(int id);

        /**************************************
        Save functions
        *************************************/
        void SaveLocation(Location loc);
        void SaveLocImage(LocImage img);
        void SaveLocHourCat(LocHourCats cat);
        void SaveLocHours(LocHours hours);
        void SaveLocService(LocServices service);
        void SaveLocPhoneNum(LocPhoneNums phone);
        void SaveLocPhoneExt(LocPhoneExts ext);
        void SaveLog(DbChangeLog log);
        /**************************************
        Delete functions
        *************************************/
        Location DeleteLocation(int id);
        LocHourCats DeleteLocHourCat(int id);
        LocHours DeleteLocHour(int id);
        LocPhoneNums DeleteLocPhoneNum(int id);
        LocPhoneExts DeleteLocPhoneExt(int id);
        LocServices DeleteLocService(int id);
        LocImage DeleteLocImage(int id);

        IEnumerable<LocServices> LocServicesByLocId(int id);
        IEnumerable<LocPhoneNums> LocPhoneNumsByLocId(int id);
        IEnumerable<LocHourCats> LocHoursByLocId(int id);
    }
}
