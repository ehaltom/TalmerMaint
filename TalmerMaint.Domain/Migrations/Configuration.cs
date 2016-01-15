namespace TalmerMaint.Domain.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TalmerMaint.Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<TalmerMaint.Domain.Concrete.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TalmerMaint.Domain.Concrete.EFDbContext context)
        {
            context.Locations.AddOrUpdate(l => l.Name,
           new Location
           {
               Name = "Algonac",
               Address1 = "301 Summer Street",
               City = "Algonac",
               Zip = "48001",
               State = "MI",
               LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "810-794-4958"
}
},
               LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
    {
        new LocHours{
            Days = "Mon - Fri",
            Hours = "9am-5pm"
        },
        new LocHours{
            Days = "Sat",
            Hours = "9am-12pm"
        }
    }
    }
},
               AtmOnly = false,
               NoAtm = false,
               Latitude = 42.617318,
               Longitude = -82.5322429
           },
new Location
{
    Name = "Amherst",
    Address1 = "1977 Cooper Foster Park",
    City = "Amherst",
    Zip = "44001",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "440-406-5090"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.417912,
    Longitude = -82.205541
},
new Location
{
    Name = "Ann Arbor",
    Address1 = "2950 South State Street ",
    City = "Ann Arbor",
    Zip = "48104",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "734-887-3100"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
        {
        new LocHours{
        Days = "Mon - Thurs",
        Hours = "9am-5pm"
        },
        new LocHours{
        Days = "Fri",
        Hours = "9am-5pm"
        },
        new LocHours{
        Days = "Drive Thru",
        Hours = "9am-6pm"
        },
        new LocHours{
        Days = "Sat",
        Hours = "9am-12pm"
        }
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.244952,
    Longitude = -83.74054
},
new Location
{
    Name = "Auburn Hills",
    Address1 = "1988 N. Opdyke",
    City = "Auburn Hills",
    Zip = "48326",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "248-370-8200"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = true,
    Latitude = 42.670998,
    Longitude = -83.245822
},
new Location
{
    Name = "Austintown",
    Address1 = "101 S. Canfield-Niles Road",
    City = "Austintown",
    Zip = "44515",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "330-314-1360"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "9am-6pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.0996077,
    Longitude = -80.763837
},
new Location
{
    Name = "Bad Axe",
    Address1 = "833 N. VanDyke",
    City = "Bad Axe",
    Zip = "48413",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "989-269-9211"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "8:30am-5pm"
},
new LocHours{
Days = "F",
Hours = "9am-6pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "8:30am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "8:30am-1pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 43.820569,
    Longitude = -83.000994
},
new Location
{
    Name = "Birmingham",
    Address1 = "980 South Old Woodward",
    City = "Birmingham",
    Zip = "48009",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "248-647-1026"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.539766,
    Longitude = -83.207577
},
new Location
{
    Name = "Boardman",
    Address1 = "724 Boardman-Poland Road",
    City = "Boardman",
    Zip = "44512",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "330-965-6972"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat Drive-Thru",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.024742,
    Longitude = -80.641953
},
new Location
{
    Name = "Brighton",
    Address1 = "8700 North Second Street",
    City = "Brighton",
    Zip = "48116",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "810-220-1199"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-5pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "9am-6pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.537651,
    Longitude = -83.786588
},
new Location
{
    Name = "Brookfield",
    Address1 = "7290 Warren-Sharon Road",
    City = "Brookfield",
    Zip = "44403",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "330-314-1288"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.233494,
    Longitude = -80.5552699
},
new Location
{
    Name = "Canfield",
    Address1 = "3801 Boardman Canfield Road",
    City = "Canfield",
    Zip = "44406",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "330-533-8530"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "9am-6pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.023955,
    Longitude = -80.715858
},
new Location
{
    Name = "Caro",
    Address1 = "345 North State Street",
    City = "Caro",
    Zip = "48723",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "989-673-6152"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "8:30am-5pm"
},
new LocHours{
Days = "F",
Hours = "9am-6pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "8:30am-6pm"
},
new LocHours{
Days = "Sat-Drive-Thru",
Hours = "8:30am-1pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 43.490673,
    Longitude = -83.394196
},
new Location
{
    Name = "Chicago",
    Address1 = "333 West Wacker Drive",
    Address2 = "Suite 710",
    City = "Chicago",
    Zip = "60606",
    State = "IL",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "312-912-6000"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "8:30-5:00"
}
}
    }
},
    AtmOnly = false,
    NoAtm = true,
    Latitude = 41.8860664,
    Longitude = -87.6357277
},
new Location
{
    Name = "Cincinnati (Mortgage Services Only)",
    Address1 = "7373 Beechmont Avenue",
    Address2 = "Suite 100",
    City = "Cincinnati",
    Zip = "45230",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "513-232-0800"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = true,
    Latitude = 39.072377,
    Longitude = -84.353308
},
new Location
{
    Name = "Cleveland (Commercial, Wealth & Treasury Services Only)",
    Address1 = "23240 Chagrin Boulevard",
    Address2 = "Suite 600 (Commerce Park IV)",
    City = "Cleveland",
    Zip = "44122",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "800-456-1500"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.4621511,
    Longitude = -81.5155239
},
new Location
{
    Name = "Clinton Township",
    Address1 = "34950 Little Mack Avenue",
    City = "Clinton Twp",
    Zip = "48035",
    State = "MI",

    AtmOnly = true,
    NoAtm = false,
    Latitude = 42.553505,
    Longitude = -82.9076429
},
new Location
{
    Name = "Cortland",
    Address1 = "325 S. High Street",
    City = "Cortland",
    Zip = "44410",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "330-314-1275"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.3241299,
    Longitude = -80.726992
},
new Location
{
    Name = "Davison",
    Address1 = "727 South State Road",
    City = "Davison",
    Zip = "48423",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "810-653-5383"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "Drive-Thru"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 43.022394,
    Longitude = -83.51719
},
new Location
{
    Name = "Centerville (Mortgage Services Only)",
    Address1 = "170 E. Spring Valley Pike ",
    Address2 = "Suite B",
    City = "Dayton",
    Zip = "45458",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "937-436-5020"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "8:30am-5:00pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = true,
    Latitude = 39.612709,
    Longitude = -84.159017
},
new Location
{
    Name = "Downtown Detroit",
    Address1 = "645 Griswold",
    Address2 = "Suite 70",
    City = "Detroit",
    Zip = "48226",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "313-967-9700"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "8:30am-4:30pm"
},
new LocHours{
Days = "ATM accessible only during banking center",
Hours = "hours"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.330465,
    Longitude = -83.04751
},
new Location
{
    Name = "Detroit Vanguard/Second Ebenezer (Mortgage Services Only)",
    Address1 = "2795 East Grand Boulevard",
    City = "Detroit",
    Zip = "48211",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "248-269-6293"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-4:30pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = true,
    Latitude = 42.373783,
    Longitude = -83.062934
},
new Location
{
    Name = "Dublin",
    Address1 = "6033 Perimeter Drive",
    City = "Dublin",
    Zip = "43017",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "614-761-2302"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 40.102089,
    Longitude = -83.152809
},
new Location
{
    Name = "Elkhart",
    Address1 = "303 South Third Street",
    City = "Elkhart",
    Zip = "46516",
    State = "IN",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "574-295-9600"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5:30pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.684315,
    Longitude = -85.975453
},
new Location
{
    Name = "Elyria",
    Address1 = "111 Antioch Drive",
    City = "Elyria",
    Zip = "44035",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "440-406-5070"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.416148,
    Longitude = -82.077947
},
new Location
{
    Name = "Elyria",
    Address1 = "361 Midway Boulevard",
    City = "Elyria",
    Zip = "44035",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "440-406-5080"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.399181,
    Longitude = -82.11005
},
new Location
{
    Name = "Elyria",
    Address1 = "200 Middle Avenue",
    City = "Elyria",
    Zip = "44035",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "440-406-5100"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4:30pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-5:00pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = true,
    Latitude = 41.366303,
    Longitude = -82.106617
},
new Location
{
    Name = "Elyria (Drive-Up Only)",
    Address1 = "860 East Broad Street",
    City = "Elyria",
    Zip = "44035",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "440-406-5086"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.36527,
    Longitude = -82.079799
},
new Location
{
    Name = "Farmington",
    Address1 = "33205 Grand River Avenue",
    City = "Farmington",
    Zip = "48336",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "248-615-0407"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.463776,
    Longitude = -83.3747099
},
new Location
{
    Name = "Farmington Hills",
    Address1 = "37386 W. 12 Mile Road",
    City = "Farmington Hills",
    Zip = "48331",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "248-848-9030"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.4982656,
    Longitude = -83.4166472
},
new Location
{
    Name = "Farmington Hills",
    Address1 = "31731 Northwestern Highway",
    Address2 = "Suite 100",
    City = "Farmington Hills",
    Zip = "48334",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "248-855-0550"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = true,
    Latitude = 42.51877,
    Longitude = -83.341352
},
new Location
{
    Name = "Flint",
    Address1 = "6120 Fenton Road",
    City = "Flint",
    Zip = "48507",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "810-232-3810"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-5pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat-Drive-Thru",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.9408641,
    Longitude = -83.6924022
},
new Location
{
    Name = "Flint",
    Address1 = "3213 North Genesee Road",
    City = "Flint",
    Zip = "48506",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "810-736-0440"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-5pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat-Drive-Thru",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 43.053292,
    Longitude = -83.617185
},
new Location
{
    Name = "Flint",
    Address1 = "4409 Miller Road",
    City = "Flint",
    Zip = "48507",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "810-732-6360"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat-Drive-Thru",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.977752,
    Longitude = -83.765717
},
new Location
{
    Name = "Flushing",
    Address1 = "220 East Main Street",
    City = "Flushing",
    Zip = "48433",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "810-659-7712"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 43.06262,
    Longitude = -83.853427
},
new Location
{
    Name = "Fort Gratiot",
    Address1 = "4778 24th Avenue",
    City = "Fort Gratiot",
    Zip = "48059",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "810-385-2672"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "8:30am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "8:30am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 43.046648,
    Longitude = -82.456484
},
new Location
{
    Name = "Frankenmuth",
    Address1 = "170 West Genesee Street",
    City = "Frankenmuth",
    Zip = "48734",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "989-652-1129"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "8:30am-5pm"
},
new LocHours{
Days = "F",
Hours = "9am-6pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "8:30am-6pm"
},
new LocHours{
Days = "Sat-Drive-Thru",
Hours = "8:30am-1pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 43.336093,
    Longitude = -83.739196
},
new Location
{
    Name = "Goshen",
    Address1 = "511 West Lincoln Avenue",
    City = "Goshen",
    Zip = "46526",
    State = "IN",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "574-533-2006"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.586865,
    Longitude = -85.843638
},
new Location
{
    Name = "Grafton",
    Address1 = "351 North Main Street",
    City = "Grafton",
    Zip = "44044",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "440-406-5075"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.288424,
    Longitude = -82.066104
},
new Location
{
    Name = "Grand Haven",
    Address1 = "333 Washington Avenue",
    City = "Grand Haven",
    Zip = "49417",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "616-846-1930"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
},
new LocHours{
Days = "Sat",
Hours = "Drive-Thru"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 43.063487,
    Longitude = -86.228042
},
new Location
{
    Name = "Grand Rapids (Commercial Lending Services Available)",
    Address1 = "4505 Cascade Road S.E.",
    City = "Grand Rapids",
    Zip = "49546",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "616-974-0200"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.946614,
    Longitude = -85.558541
},
new Location
{
    Name = "Grosse Pointe Farms",
    Address1 = "99 Kercheval Avenue",
    City = "Grosse Pointe Farms",
    Zip = "48236",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "313-647-0666"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.395466,
    Longitude = -82.90315
},
new Location
{
    Name = "Grosse Pointe Woods",
    Address1 = "20276 Mack Avenue",
    City = "Grosse Pointe Woods",
    Zip = "48236",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "313-640-9051"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.436653,
    Longitude = -82.90729
},
new Location
{
    Name = "Hamtramck",
    Address1 = "9252 Joseph Campau Street",
    City = "Hamtramck",
    Zip = "48212",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "313-875-2000"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat-Drive-Thru",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.393622,
    Longitude = -83.0554245
},
new Location
{
    Name = "Harbor Beach",
    Address1 = "106 South Huron Avenue",
    City = "Harbor Beach",
    Zip = "48441",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "989-479-3255"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "8:30am-5pm"
},
new LocHours{
Days = "F",
Hours = "9am-6pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "8:30am-6pm"
},
new LocHours{
Days = "Sat-Drive-Thru",
Hours = "8:30am-1pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 43.844582,
    Longitude = -82.651491
},
new Location
{
    Name = "Henderson",
    Address1 = "1700 W. Horizon Ridge Parkway",
    Address2 = "Suite 101",
    City = "Henderson",
    Zip = "89012",
    State = "NV",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "702-990-5900"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-4pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = true,
    Latitude = 36.012745,
    Longitude = -115.062089
},
new Location
{
    Name = "Holland",
    Address1 = "240 East 8th Street",
    City = "Holland",
    Zip = "49423",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "616-394-9600"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.790149,
    Longitude = -86.096592
},
new Location
{
    Name = "Imlay City",
    Address1 = "715 S. Cedar Street",
    City = "Imlay City",
    Zip = "48444",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "810-724-0518"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
},
new LocHours{
Days = "Sat-Drive-Thru",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 43.0195259,
    Longitude = -83.0720802
},
new Location
{
    Name = "Kimball Township",
    Address1 = "2855 Wadhams Road",
    City = "Kimball Township",
    Zip = "48074",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "810-982-8505"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "8:30am-5pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.9891574,
    Longitude = -82.5374829
},
new Location
{
    Name = "Lapeer",
    Address1 = "567 E. Genesee Street",
    City = "Lapeer",
    Zip = "48446",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "810-245-4509"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-5pm"
},
new LocHours{
Days = "Sat-Drive-Thru",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 43.0507727,
    Longitude = -83.3128397
},
new Location
{
    Name = "Lexington",
    Address1 = "5536 Main Street",
    City = "Lexington",
    Zip = "48450",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "810-359-7947"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat-Drive-Thru",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 43.2674067,
    Longitude = -82.5309349
},
new Location
{
    Name = "Livonia",
    Address1 = "17900 Haggerty Road",
    City = "Livonia",
    Zip = "48152",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "734 805-4600"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.4156812,
    Longitude = -83.4326195
},
new Location
{
    Name = "Madison Heights",
    Address1 = "1800 E. 12 Mile Road",
    City = "Madison Heights",
    Zip = "48071",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "248-548-2900"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.504752,
    Longitude = -83.086868
},
new Location
{
    Name = "Marine City",
    Address1 = "210 S. Parker Street",
    City = "Marine City",
    Zip = "48039",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "810-765-3501"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "8:30am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "8:30am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.718493,
    Longitude = -82.501068
},
new Location
{
    Name = "Marysville",
    Address1 = "2015 Gratiot Boulevard",
    City = "Marysville",
    Zip = "48040",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "810-364-5757"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "8:30am-5pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.915778,
    Longitude = -82.485058
},
new Location
{
    Name = "Mt. Clemens",
    Address1 = "100 N. Main Street",
    City = "Mt. Clemens",
    Zip = "48043",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "586-783-4500"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat-Drive-Thru",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.599662,
    Longitude = -82.875843
},
new Location
{
    Name = "Muskegon",
    Address1 = "281 Seminole Road",
    City = "Muskegon",
    Zip = "49444",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "231-737-4431"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 43.188336,
    Longitude = -86.251903
},
new Location
{
    Name = "New Middletown",
    Address1 = "10416 Main Street",
    City = "New Middletown",
    Zip = "44442",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "330-314-1390"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 40.9669049,
    Longitude = -80.563181
},
new Location
{
    Name = "Niles",
    Address1 = "6002 Youngstown-Warren Road",
    City = "Niles",
    Zip = "44446",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "330-314-1285"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.2066471,
    Longitude = -80.7422494
},
new Location
{
    Name = "North Olmsted (Mortgage Services Only)",
    Address1 = "24950 Country Club Boulevard",
    Address2 = "Suite 107",
    City = "North Olmsted",
    Zip = "44070",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "440-779-0807"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = true,
    Latitude = 41.416519,
    Longitude = -81.899023
},
new Location
{
    Name = "North Ridgeville",
    Address1 = "35423 Center Ridge Road",
    City = "North Ridgeville",
    Zip = "44039",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "440-406-5065"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.391492,
    Longitude = -82.011888
},
new Location
{
    Name = "Plymouth (Mortgage Services Only)",
    Address1 = "815 Church Street",
    City = "Plymouth",
    Zip = "48170",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "734-805-4613"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = true,
    Latitude = 42.373185,
    Longitude = -83.470098
},
new Location
{
    Name = "Poland",
    Address1 = "2 South Main Street",
    City = "Poland",
    Zip = "44514",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "330-314-1395"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat-Drive-Thru",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.0242196,
    Longitude = -80.6145935
},
new Location
{
    Name = "Port Hope",
    Address1 = "4474 Main Street",
    City = "Port Hope",
    Zip = "48468",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "989-428-4111"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "TH",
Hours = "9am-4pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "8:30am-5pm"
},
new LocHours{
Days = "F",
Hours = "9am-6pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "8:30am-6pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 43.941757,
    Longitude = -82.713915
},
new Location
{
    Name = "Port Huron",
    Address1 = "1527 Hancock Street",
    City = "Port Huron",
    Zip = "48060",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "810-985-5181"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "8:30am-5pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 43.0018333,
    Longitude = -82.4377426
},
new Location
{
    Name = "Port Huron",
    Address1 = "525 Water Street",
    City = "Port Huron",
    Zip = "48060",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "810-990-1850"
},
new LocPhoneNums{
Name = "Commercial/Business Banking",
Number = "810-985-0445"
},
new LocPhoneNums{
Name = "Wealth Management",
Number = "810-966-8710"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.9753374,
    Longitude = -82.4256098
},
new Location
{
    Name = "Port Huron Township",
    Address1 = "3136 Lapeer Road",
    City = "Port Huron Township",
    Zip = "48060",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "810-984-1578"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.979124,
    Longitude = -82.462614
},
new Location
{
    Name = "Portage",
    Address1 = "800 East Milham",
    City = "Portage",
    Zip = "49002",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "269-323-2200"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-5pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.230019,
    Longitude = -85.580814
},
new Location
{
    Name = "Ravenna",
    Address1 = "999 East Main Street",
    City = "Ravenna",
    Zip = "44266",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "330-298-0510"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.158349,
    Longitude = -81.225317
},
new Location
{
    Name = "Rochester",
    Address1 = "440 Main Street",
    City = "Rochester",
    Zip = "48307",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "248-608-5100"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-4pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.6821303,
    Longitude = -83.1338296
},

new Location
{
    Name = "Rootstown",
    Address1 = "4183 Tallmadge Road",
    City = "Rootstown",
    Zip = "44272",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "330-298-2030"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.099557,
    Longitude = -81.242304
},
new Location
{
    Name = "St. Johns (Commercial Lending Services Only)",
    Address1 = "1000 East Sturgis Street",
    Address2 = "Suite 1",
    City = "Saint Johns",
    Zip = "48879",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "989-316-7227"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = true,
    Latitude = 42.993876,
    Longitude = -84.543058
},
new Location
{
    Name = "Sandusky",
    Address1 = "629 W. Sanilac Road",
    City = "Sandusky",
    Zip = "48471",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "810-648-3322"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "8:30am-"
},
new LocHours{
Days = "Fri",
Hours = "8:30am-5pm"
},
new LocHours{
Days = "Sat-Drive-Thru",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 43.4207682,
    Longitude = -82.8545046
},
new Location
{
    Name = "Sebewaing",
    Address1 = "668 Unionville Road",
    City = "Sebewaing",
    Zip = "48759",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "989-883-2400"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "8:30am-5pm"
},
new LocHours{
Days = "F",
Hours = "9am-6pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "8:30am-6pm"
},
new LocHours{
Days = "Sat-Drive-Thru",
Hours = "8:30am-1pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 43.740606,
    Longitude = -83.444552
},
new Location
{
    Name = "Shelby Township",
    Address1 = "50787 Corporate Drive",
    City = "Shelby Township",
    Zip = "48315",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "586-739-4033"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.669176,
    Longitude = -83.011187
},
new Location
{
    Name = "Solon",
    Address1 = "6150 Enterprise Parkway",
    City = "Solon",
    Zip = "44139",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "440-914-0683"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.392718,
    Longitude = -81.4645929
},
new Location
{
    Name = "Southfield",
    Address1 = "24805 W. Twelve Mile Road",
    City = "Southfield",
    Zip = "48034",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "248-358-9540"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.5006423,
    Longitude = -83.2894164
},
new Location
{
    Name = "St. Clair",
    Address1 = "270 Clinton Avenue",
    City = "St. Clair",
    Zip = "48079",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "810-329-4705"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.82153,
    Longitude = -82.487898
},
new Location
{
    Name = "Sterling Heights",
    Address1 = "3801 E. Metropolitan Parkway",
    City = "Sterling Heights",
    Zip = "48310",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "586-939-2834"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat-Drive-Thru",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.565114,
    Longitude = -83.071202
},
new Location
{
    Name = "Troy",
    Address1 = "2301 W. Big Beaver",
    City = "Troy",
    Zip = "48084",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "248-244-6800"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
},
new LocHours{
Days = "ATM accessible only during banking center",
Hours = "hours"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.560165,
    Longitude = -83.1781308
},
new Location
{
    Name = "Warren",
    Address1 = "14801 12 Mile Road",
    City = "Warren",
    Zip = "48088",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "586-777-7010"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Fri",
Hours = "9am-5pm"
},
new LocHours{
Days = "Sat-Drive-Thru",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.508906,
    Longitude = -82.9733509
},
new Location
{
    Name = "Warren",
    Address1 = "185 East Market Street",
    City = "Warren",
    Zip = "44481",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "330-314-1270"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "F",
Hours = "9am-5pm"
},
new LocHours{
Days = "Tue - Thurs",
Hours = "9am-4pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.236381,
    Longitude = -80.816419
},
new Location
{
    Name = "Warren",
    Address1 = "4460 Mahoning Avenue NW",
    City = "Warren",
    Zip = "44483",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "330-314-1300"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.2815398,
    Longitude = -80.8443709
},
new Location
{
    Name = "Warren",
    Address1 = "8226 East Market Street",
    City = "Warren",
    Zip = "44484",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "330-314-1290"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "9am-6pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-1pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.2382038,
    Longitude = -80.7426934
},
new Location
{
    Name = "Warren",
    Address1 = "2001 Elm Road NE",
    City = "Warren",
    Zip = "44483",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "330-314-1280"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.2535968,
    Longitude = -80.7924457
},
new Location
{
    Name = "West Bloomfield",
    Address1 = "7950 W. Maple Road",
    City = "West Bloomfield",
    Zip = "48322",
    State = "MI",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "248-669-5133"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-5pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 42.541368,
    Longitude = -83.4372099
},
new Location
{
    Name = "Youngstown",
    Address1 = "4682 Belmont Avenue",
    City = "Youngstown",
    Zip = "44505",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "330-314-1410"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.1659663,
    Longitude = -80.6648181
},
new Location
{
    Name = "Youngstown",
    Address1 = "3516 S. Meridian Road",
    City = "Youngstown",
    Zip = "44511",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "330-314-1375"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.064387,
    Longitude = -80.711594
},
new Location
{
    Name = "Youngstown",
    Address1 = "25 Market Street",
    Address2 = "Suite 3",
    City = "Youngstown",
    Zip = "44503",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "330-314-1370"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-4:30pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.099288,
    Longitude = -80.649409
},
new Location
{
    Name = "Youngstown",
    Address1 = "3900 Market Street",
    City = "Youngstown",
    Zip = "44512",
    State = "OH",
    LocPhoneNums = new List<LocPhoneNums>
{
new LocPhoneNums{
Name = "Phone",
Number = "330-314-1380"
}
},
    LocHourCats = new List<LocHourCats>
{
     new LocHourCats{
          Name = "Hours",
          LocHours = new List<LocHours>
{
new LocHours{
Days = "Mon - Thurs",
Hours = "9am-4pm"
},
new LocHours{
Days = "Drive Thru",
Hours = "9am-5pm"
},
new LocHours{
Days = "Fri",
Hours = "9am-6pm"
},
new LocHours{
Days = "Sat-Drive-Thru",
Hours = "9am-12pm"
}
}
    }
},
    AtmOnly = false,
    NoAtm = false,
    Latitude = 41.060386,
    Longitude = -80.662474
}

                );


        }
    }
}
