using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TalmerMaint.Domain.Abstract;
using TalmerMaint.Domain.Entities;
using System.Linq;

namespace TalmerMaint.Domain.Concrete
{
    public class EFLocationRepository : ILocationRepository
    {
        private EFDbContext context = new EFDbContext();

        public Location Find(int id)
        {
            return context.Locations.Find(id);
        }
        public IEnumerable<Location> Locations { get { return
                    context.Locations
                        .Include("LocHourCats")
                        .Include("LocPhoneNums")
                        .Include("LocServices")
                        .ToList();
                    } }
       
        public IEnumerable<LocServices> LocServicesByLocId(int id)
        {
            return context.LocServices.Where(l => l.LocationId == id).ToList();
        }
        public IEnumerable<LocPhoneNums> LocPhoneNumsByLocId(int id)
        {
            return context.LocPhoneNums.Where(l => l.LocationId == id).ToList();
        }
        public IEnumerable<LocHourCats> LocHourCatsByLocId(int id)
        {
            return context.LocHourCats
                .Include("LocHours")
                .Where(l => l.LocationId == id).ToList();
        }
        public IEnumerable<LocHourCats> LocHoursByLocId(int id)
        {
            return context.LocHourCats
                .Include("LocHours")
                .Where(l => l.LocationId == id)
                .ToList();
        }

        public void SaveLocation(Location loc, bool addImg)
        {
            if(loc.Id == 0)
            {
                context.Locations.Add(loc);
            }
            else
            {
                Location dbEntry = context.Locations.Find(loc.Id);
                if(dbEntry != null)
                {
                    dbEntry.Name = loc.Name;
                    dbEntry.Subtitle = loc.Subtitle;
                    dbEntry.Address1 = loc.Address1;
                    dbEntry.Address2 = loc.Address2;
                    dbEntry.City = loc.City;
                    dbEntry.State = loc.State;
                    dbEntry.Zip = loc.Zip;
                    dbEntry.Latitude = loc.Latitude;
                    dbEntry.Longitude = loc.Longitude;
                    /****
                    Update-Liked
                    Images are saved to the database because the images are used on multiple 
                    sites, therefore cannot be saved in a local directory. Perhaps we can save these images in the cdn
                    that Josh set up.
                    ****/
                    if(addImg) { 
                        dbEntry.ImageData = loc.ImageData;
                        dbEntry.ImageMimeType = loc.ImageMimeType;
                    }
                    dbEntry.Description = loc.Description;
                    dbEntry.ManagerName = loc.ManagerName;
                    dbEntry.NoAtm = loc.NoAtm;
                    dbEntry.AtmOnly = loc.AtmOnly;
                }
            }
            SaveXMLFile();
            context.SaveChanges();
        }
        private void SaveXMLFile()
        {
            DataTable locTable = new DataTable();
            locTable.TableName = "Locations";
            locTable.Columns.Add("Id", typeof(int));
            locTable.Columns.Add("Name", typeof(string));
            locTable.Columns.Add("Subtitle", typeof(string));
            locTable.Columns.Add("Address1", typeof(string));
            locTable.Columns.Add("Address2", typeof(string));
            locTable.Columns.Add("City", typeof(string));
            locTable.Columns.Add("State", typeof(string));
            locTable.Columns.Add("Zip", typeof(string));
            locTable.Columns.Add("AtmOnly", typeof(bool));
            locTable.Columns.Add("NoAtm", typeof(bool));
            locTable.Columns.Add("Latitude", typeof(double));
            locTable.Columns.Add("Longitude", typeof(double));
            locTable.Columns.Add("ImageData", typeof(byte[]));
            locTable.Columns.Add("ImageMimeType", typeof(string));
            locTable.Columns.Add("ManagerName", typeof(string));
            foreach (Location loc in context.Locations)
            {
                
                locTable.Rows.Add(new object[] {
                    loc.Id,
                    loc.Name,
                    loc.Subtitle,
                    loc.Address1,
                    loc.Address2,
                    loc.City,
                    loc.State,
                    loc.Zip,
                    loc.AtmOnly,
                    loc.NoAtm,
                    loc.Latitude,
                    loc.Longitude,
                    loc.ImageData,
                    loc.ImageMimeType,
                    loc.ManagerName});
                
                
            }
            locTable.WriteXml("C:/SourceControl_Git/Locations.xml");
        }
        public Location DeleteLocation(int id)
        {
            Location dbEntry = context.Locations.Find(id);
            if(dbEntry != null)
            {
                context.Locations.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }


    }
}
