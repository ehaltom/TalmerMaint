using System.Collections.Generic;
using System.Linq;
using System.Data;
using TalmerMaint.Domain.Abstract;
using TalmerMaint.Domain.Entities;
using System.Web;
using System.Data.Linq;
using System;

namespace TalmerMaint.Domain.Concrete
{
    public class EFLocationRepository : ILocationRepository
    {
        private EFDbContext context = new EFDbContext();



        public IEnumerable<Location> Locations { get { 
                return context.Locations
                        .Include("LocHourCats")
                        .Include("LocPhoneNums")
                        .Include("LocServices")
                        .ToList();
            }
        }

        public Location LocationByID(int id)
        {
            return context.Locations
                .Include("LocHourCats")
                .Include("LocPhoneNums")
                .Include("LocServices")
                .Include("LocImage")
                .FirstOrDefault(l => l.Id == id);
                
        }
        public LocImage ImageByLocationID(int id)
        {
            LocImage img = (from n in context.LocImages
                           where n.LocationId == id
                           where n.FeaturedImg == true
                           select n).FirstOrDefault();
            
            /*LocImage img = context.LocImages
                .FirstOrDefault(l => l.LocationId == id);
            */
            
            return (img != null) ? img: new LocImage();

        }


        public IEnumerable<LocServices> LocServices { get { return context.LocServices; } }
        public IEnumerable<LocImage> LocImages { get { return context.LocImages; } }
        public IEnumerable<LocHourCats> LocHourCats { get { return context.LocHourCats; } }
        public IEnumerable<LocHours> LocHours { get { return context.LocHours; } }
        public IEnumerable<LocPhoneNums> LocPhoneNums { get { return context.LocPhoneNums; } }
        public IEnumerable<LocPhoneExts> LocPhoneExts { get { return context.LocPhoneExts; } }
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


        /**************************************
        XML functions
        *************************************/
        private void SaveLocationsXMLFile()
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
                    loc.ManagerName});
                
                
            }
            locTable.WriteXml(HttpContext.Current.Server.MapPath("~/XMLOutput/Locations.xml"));
        }
        private void SaveLocHoursXMLFile()
        {
            DataSet dataSet = new DataSet("HourInfo");
            DataTable catTable = new DataTable("cats");
            catTable.TableName = "LocHourCats";
            catTable.Columns.Add("Id", typeof(int));
            catTable.Columns.Add("Name", typeof(string));
            catTable.Columns.Add("LocationId", typeof(int));
            catTable.PrimaryKey = new DataColumn[] { catTable.Columns["Id"] };



            DataTable hoursTable = new DataTable("hours");
            hoursTable.TableName = "LocHours";
            hoursTable.Columns.Add("Id", typeof(int));
            hoursTable.Columns.Add("Days", typeof(string));
            hoursTable.Columns.Add("Hours", typeof(string));
            hoursTable.Columns.Add("Priority", typeof(int));
            hoursTable.Columns.Add("LocHourCatsId", typeof(int));
            
            hoursTable.PrimaryKey = new DataColumn[] { hoursTable.Columns["Id"] };

            dataSet.Tables.Add(catTable);
            dataSet.Tables.Add(hoursTable);
            
           foreach (LocHourCats cat in context.LocHourCats)
            {

                catTable.Rows.Add(new object[] {
                    cat.Id,
                    cat.Name,
                    cat.LocationId
                    
                });

            }
            foreach (LocHours hours in context.LocHours)
            {

                hoursTable.Rows.Add(new object[] {
                    hours.Id,
                    hours.Days,
                    hours.Hours,
                    hours.Priority,
                    hours.LocHourCatsId

                    });


            }
            foreach (DataColumn dc in catTable.Columns)
            {
                dc.ColumnMapping = MappingType.Attribute;
            }
            DataRelation drel = new DataRelation("hoursJoin",catTable.Columns["Id"], hoursTable.Columns["LocHourCatsId"],true);
            drel.Nested = true;
             dataSet.Relations.Add(drel);
           

            
            dataSet.WriteXml(HttpContext.Current.Server.MapPath("~/XMLOutput/LocHourCats.xml"));
        }
        private void SaveLocServicesXMLFile()
        {
            DataTable locTable = new DataTable("LocServices");
            locTable.Columns.Add("Id", typeof(int));
            locTable.Columns.Add("Featured", typeof(bool));
            locTable.Columns.Add("Name", typeof(string));
            locTable.Columns.Add("Description", typeof(string));
            locTable.Columns.Add("IconClassName", typeof(string));
            locTable.Columns.Add("LocationId", typeof(int));
            foreach (LocServices loc in context.LocServices)
            {

                locTable.Rows.Add(new object[] {
                    loc.Id,
                    loc.Featured,
                    loc.Name,
                    loc.Description,
                    loc.IconClassName,
                    loc.LocationId

                    });


            }
            locTable.WriteXml(HttpContext.Current.Server.MapPath("~/XMLOutput/LocServices.xml"));
        }
        private void SaveLocImageXMLFile()
        {
            DataTable locTable = new DataTable("LocImage");
            locTable.Columns.Add("Id", typeof(int));
            locTable.Columns.Add("FeaturedImg", typeof(bool));
            locTable.Columns.Add("ImageData", typeof(byte[]));
            locTable.Columns.Add("ImageMimeType", typeof(string));
            locTable.Columns.Add("LocationId", typeof(int));
            foreach (LocImage loc in context.LocImages)
            {

                locTable.Rows.Add(new object[] {
                    loc.Id,
                    loc.FeaturedImg,
                    loc.ImageData,
                    loc.ImageMimeType,
                    loc.LocationId
                    });


            }
            locTable.WriteXml(HttpContext.Current.Server.MapPath("~/XMLOutput/LocImages.xml"));
        }
        private void SaveLocPhonesXMLFile()
        {
            DataSet dataSet = new DataSet("LocPhones");
            DataTable phoneTable = new DataTable("phones");
            phoneTable.TableName = "PhoneNums";
            phoneTable.Columns.Add("Id", typeof(int));
            phoneTable.Columns.Add("Name", typeof(string));
            phoneTable.Columns.Add("Number", typeof(string));
            phoneTable.Columns.Add("LocationId", typeof(int));
            phoneTable.PrimaryKey = new DataColumn[] { phoneTable.Columns["Id"] };



            DataTable extTable = new DataTable("exts");
            extTable.TableName = "PhoneExts";
            extTable.Columns.Add("Id", typeof(int));
            extTable.Columns.Add("Name", typeof(string));
            extTable.Columns.Add("Number", typeof(string));
            extTable.Columns.Add("LocPhoneNumsId", typeof(int));

            extTable.PrimaryKey = new DataColumn[] { extTable.Columns["Id"] };

            dataSet.Tables.Add(phoneTable);
            dataSet.Tables.Add(extTable);

            foreach (LocPhoneNums phone in context.LocPhoneNums)
            {

                phoneTable.Rows.Add(new object[] {
                    phone.Id,
                    phone.Name,
                    phone.Number,
                    phone.LocationId

                });

            }
            foreach (LocPhoneExts hours in context.LocPhoneExts)
            {

                extTable.Rows.Add(new object[] {
                    hours.Id,
                    hours.Name,
                    hours.Number,
                    hours.LocPhoneNumsId

                    });


            }
            foreach (DataColumn dc in phoneTable.Columns)
            {
                dc.ColumnMapping = MappingType.Attribute;
            }
            DataRelation drel = new DataRelation("hoursJoin", phoneTable.Columns["Id"], extTable.Columns["LocPhoneNumsId"], true);
            drel.Nested = true;
            dataSet.Relations.Add(drel);



            dataSet.WriteXml(HttpContext.Current.Server.MapPath("~/XMLOutput/LocPhones.xml"));
        }

        /**************************************
        Save functions
        *************************************/
        public void SaveLocation(Location loc)
        {
            if (loc.Id == 0)
            {
                context.Locations.Add(loc);
            }
            else
            {
                Location dbEntry = context.Locations.Find(loc.Id);
                if (dbEntry != null)
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

                    dbEntry.Description = loc.Description;
                    dbEntry.ManagerName = loc.ManagerName;
                    dbEntry.NoAtm = loc.NoAtm;
                    dbEntry.AtmOnly = loc.AtmOnly;
                }
            }

            context.SaveChanges();
            SaveLocationsXMLFile();
        }
        public void SaveLocHourCat(LocHourCats hourCat)
        {
            if (hourCat.Id == 0)
            {
                context.LocHourCats.Add(hourCat);
            }
            else
            {
                LocHourCats dbEntry = context.LocHourCats.Find(hourCat.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = hourCat.Name;
                    dbEntry.LocationId = hourCat.LocationId;
                }
            }
            context.SaveChanges();
            SaveLocHoursXMLFile();
        }
        public void SaveLocHours(LocHours hours)
        {
            if (hours.Id == 0)
            {
                context.LocHours.Add(hours);
            }
            else
            {
                LocHours dbEntry = context.LocHours.Find(hours.Id);
                if (dbEntry != null)
                {
                    dbEntry.Days = hours.Days;
                    dbEntry.Hours = hours.Hours;
                    dbEntry.Priority = hours.Priority;
                }
            }
            context.SaveChanges();
            SaveLocHoursXMLFile();
        }
        public void SaveLocService(LocServices service)
        {
            if (service.Id == 0)
            {
                context.LocServices.Add(service);
            }
            else
            {
                LocServices dbEntry = context.LocServices.Find(service.Id);
                if (dbEntry != null)
                {
                    dbEntry.Featured = service.Featured;
                    dbEntry.Name = service.Name;
                    dbEntry.Description = service.Description;
                    dbEntry.Featured = service.Featured;
                    dbEntry.IconClassName = service.IconClassName;
                    dbEntry.LocationId = service.LocationId;
                }
            }
            context.SaveChanges();
            SaveLocServicesXMLFile();
        }
        public void SaveLocImage(LocImage image)
        {
            if (image.Id == 0)
            {
                context.LocImages.Add(image);
            }
            else
            {
                LocImage dbEntry = context.LocImages.Find(image.Id);
                if (dbEntry != null)
                {
                    dbEntry.FeaturedImg = image.FeaturedImg;
                    dbEntry.ImageMimeType = image.ImageMimeType;
                    dbEntry.ImageData = image.ImageData;
                    dbEntry.LocationId = image.LocationId;
                }
            }
            context.SaveChanges();
            SaveLocImageXMLFile();
        }
        public void SaveLocPhoneNum(LocPhoneNums phone)
        {
            if (phone.Id == 0)
            {
                context.LocPhoneNums.Add(phone);
            }
            else
            {
                LocPhoneNums dbEntry = context.LocPhoneNums.Find(phone.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = phone.Name;
                    dbEntry.Number = phone.Number;
                    dbEntry.LocationId = phone.LocationId;
                }
            }
            context.SaveChanges();
            SaveLocPhonesXMLFile();
        }
        public void SaveLocPhoneExt(LocPhoneExts ext)
        {
            if (ext.Id == 0)
            {
                context.LocPhoneExts.Add(ext);
            }
            else
            {
                LocPhoneExts dbEntry = context.LocPhoneExts.Find(ext.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = ext.Name;
                    dbEntry.Number = ext.Number;
                }
            }
            context.SaveChanges();
            SaveLocPhonesXMLFile();
        }
        public void SaveLog(DbChangeLog log)
        {
            context.DbChangeLogs.Add(log);
            context.SaveChanges();
        }
        /**************************************
        Deletion functions
        *************************************/

        public Location DeleteLocation(int id)
        {
            Location dbEntry = context.Locations.Find(id);
            if(dbEntry != null)
            {
                context.Locations.Remove(dbEntry);
                context.SaveChanges();
                SaveLocationsXMLFile();
            }
            return dbEntry;
        }
        public LocHourCats DeleteLocHourCat(int id)
        {
            LocHourCats dbEntry = context.LocHourCats.Find(id);
            if (dbEntry != null)
            {
                context.LocHourCats.Remove(dbEntry);
                
                context.SaveChanges();
                SaveLocHoursXMLFile();
                SaveLocHoursXMLFile();
            }
            return dbEntry;
        }
        public LocHours DeleteLocHour(int id)
        {
            LocHours dbEntry = context.LocHours.Find(id);
            if (dbEntry != null)
            {
                context.LocHours.Remove(dbEntry);
                
                context.SaveChanges();
                SaveLocHoursXMLFile();
            }
            return dbEntry;
        }
        public LocServices DeleteLocService(int id)
        {
            LocServices dbEntry = context.LocServices.Find(id);
            if(dbEntry != null)
            {
                context.LocServices.Remove(dbEntry);

                context.SaveChanges();
                SaveLocServicesXMLFile();
            }
            return dbEntry;
        }
        public LocImage DeleteLocImage(int id)
        {
            LocImage dbEntry = context.LocImages.Find(id);
            if (dbEntry != null)
            {
                context.LocImages.Remove(dbEntry);

                context.SaveChanges();
                SaveLocImageXMLFile();
            }
            return dbEntry;
        }
        public LocPhoneNums DeleteLocPhoneNum(int id)
        {
            LocPhoneNums dbEntry = context.LocPhoneNums.Find(id);
            if (dbEntry != null)
            {
                context.LocPhoneNums.Remove(dbEntry);

                context.SaveChanges();
                SaveLocPhonesXMLFile();
            }
            return dbEntry;
        }
        public LocPhoneExts DeleteLocPhoneExt(int id)
        {
            LocPhoneExts dbEntry = context.LocPhoneExts.Find(id);
            if (dbEntry != null)
            {
                context.LocPhoneExts.Remove(dbEntry);

                context.SaveChanges();
                SaveLocPhonesXMLFile();
            }
            return dbEntry;
        }

    }
}
