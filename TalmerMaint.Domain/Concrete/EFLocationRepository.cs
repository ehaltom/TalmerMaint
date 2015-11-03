using System;
using System.Collections.Generic;
using TalmerMaint.Domain.Abstract;
using TalmerMaint.Domain.Entities;

namespace TalmerMaint.Domain.Concrete
{
    public class EFLocationRepository : ILocationRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Location> Locations { get { return context.Locations; } }

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
            context.SaveChanges();
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
