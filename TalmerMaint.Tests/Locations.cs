using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TalmerMaint.Domain.Abstract;
using TalmerMaint.Domain.Entities;
using TalmerMaint.WebUI.Controllers;
using TalmerMaint.WebUI.Models;
using TalmerMaint.WebUI.HtmlHelpers;


namespace TalmerMaint.Tests
{
    [TestClass]
    public class Locations
    {
        [TestMethod]
        public void Can_Locations_Paginate()
        {
            // Arrange
            Mock<ILocationRepository> mock = new Mock<ILocationRepository>();
            mock.Setup(m => m.Locations).Returns(new List<Location>
             {
                 new Location {Id = 1, Name = "L1" },
                 new Location {Id = 2, Name = "L2"},
                 new Location {Id = 3, Name = "L3"},
                 new Location {Id = 4, Name = "L4"},
                 new Location {Id = 5, Name = "L5"}

             });

            LocationsController controller = new LocationsController(mock.Object);
            controller.PageSize = 3;
            ViewResult indx = (ViewResult)controller.Index(null, 2);
            //Act
            LocationListViewModel result = 
                (LocationListViewModel)indx.Model;

            //Assert
            Location[] prodArray = result.Locations.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "L4");
            Assert.AreEqual(prodArray[1].Name, "L5");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            /***************************
            *
            This Test Verifies the helper method output
            by using a literal string value that
            contains double quotes
            *
            ************************/
            // Arrange - define an HTML helper - we need to do this
            // in order to apply the extension method
            HtmlHelper myHelper = null;

            // Arrange - create PagingInfo data
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            // Arrange - set up the delegate using a lambda expression
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            // Act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            // Assert
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            Mock<ILocationRepository> mock = new Mock<ILocationRepository>();
            mock.Setup(m => m.Locations).Returns(new List<Location>
             {
                 new Location {Id = 1, Name = "L1" },
                 new Location {Id = 2, Name = "L2"},
                 new Location {Id = 3, Name = "L3"},
                 new Location {Id = 4, Name = "L4"},
                 new Location {Id = 5, Name = "L5"}

             });

            // Arrange
            LocationsController controller = new LocationsController(mock.Object);

            controller.PageSize = 3;
            ViewResult indx = (ViewResult)controller.Index(null, 2);
            //Act
            LocationListViewModel result =
                (LocationListViewModel)indx.Model;

            //Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }

        [TestMethod]
        public void Can_Filter_Locations()
        {
            // Arrange
            // - create the mock repository
            Mock<ILocationRepository> mock = new Mock<ILocationRepository>();
            mock.Setup(m => m.Locations).Returns(new List<Location>
             {
                 new Location {Id = 1, Name = "L1", State="MI" },
                 new Location {Id = 2, Name = "L2", State="IL"},
                 new Location {Id = 3, Name = "L3", State="MI"},
                 new Location {Id = 4, Name = "L4", State="IN"},
                 new Location {Id = 5, Name = "L5", State="MI"}

             });

            // Arrange - create a controller and make the page size 3 items
            LocationsController controller = new LocationsController(mock.Object);
            controller.PageSize = 3;

            ViewResult indx = (ViewResult)controller.Index("MI", 1);
            
            // Action 
            Location[] result = ((LocationListViewModel)indx.Model)
                .Locations.ToArray();
            //Assert
            Assert.AreEqual(result.Length, 3);
            Assert.IsTrue(result[0].Name == "L1" && result[0].State == "MI");
            Assert.IsTrue(result[2].Name == "L5" && result[2].State == "MI");
        }

        [TestMethod]
        public void Can_Create_StateCategories()
        {
            // Arrange
            // - create the mock repository
            Mock<ILocationRepository> mock = new Mock<ILocationRepository>();
            mock.Setup(m => m.Locations).Returns(new List<Location>
             {
                 new Location {Id = 1, Name = "L1", State="MI" },
                 new Location {Id = 2, Name = "L2", State="IL"},
                 new Location {Id = 3, Name = "L3", State="MI"},
                 new Location {Id = 4, Name = "L4", State="IN"},
                 new Location {Id = 5, Name = "L5", State="MI"}

             });
            // Arrange - create the controller
            NavController target = new NavController(mock.Object);

            // Act - get the set of states
            string[] results = ((IEnumerable<string>)target.Menu().Model).ToArray();

            //Assert
            Assert.AreEqual(results.Length, 3);
            Assert.AreEqual(results[0], "IL");
            Assert.AreEqual(results[1], "IN");
            Assert.AreEqual(results[2], "MI");

        }

        [TestMethod]
        public void Get_Proper_State_Names()
        {


            //Assert
            Assert.AreEqual("Illinois", TalmerMaint.Domain.Extensions.CentralLibrary.GetStateName("IL"));
            Assert.AreEqual("Michigan", TalmerMaint.Domain.Extensions.CentralLibrary.GetStateName("MI"));
            Assert.AreEqual("California", TalmerMaint.Domain.Extensions.CentralLibrary.GetStateName("CA"));
        }

        [TestMethod]
        public void Indicates_Selected_State()
        {
            // Arrange
            // - create the mock repository
            Mock<ILocationRepository> mock = new Mock<ILocationRepository>();
            mock.Setup(m => m.Locations).Returns(new List<Location>
             {
                 new Location {Id = 1, Name = "L1", State="MI" },
                 new Location {Id = 2, Name = "L2", State="IL"},
                 new Location {Id = 3, Name = "L3", State="MI"},
                 new Location {Id = 4, Name = "L4", State="IN"},
                 new Location {Id = 5, Name = "L5", State="MI"}

             });
            // Arrange - create the controller
            NavController target = new NavController(mock.Object);

            //Arrange
            string stateToSelect = "MI";

            // Act - get the set of states
            string result = target.Menu(stateToSelect).ViewBag.SelectedState;

            //Assert
            Assert.AreEqual(result, stateToSelect);

        }

        [TestMethod]
        public void Generate_State_Specific_Location_Count()
        {
            // Arrange
            // - create the mock repository
            Mock<ILocationRepository> mock = new Mock<ILocationRepository>();
            mock.Setup(m => m.Locations).Returns(new List<Location>
             {
                 new Location {Id = 1, Name = "L1", State="MI" },
                 new Location {Id = 2, Name = "L2", State="IL"},
                 new Location {Id = 3, Name = "L3", State="MI"},
                 new Location {Id = 4, Name = "L4", State="IN"},
                 new Location {Id = 5, Name = "L5", State="MI"}

             });
            // Arrange - create the controller
            LocationsController target = new LocationsController(mock.Object);
            target.PageSize = 3;
            ViewResult indx = (ViewResult)target.Index("MI");
            ViewResult indxIl = (ViewResult)target.Index("IL");
            ViewResult indxIn = (ViewResult)target.Index("IN");
            ViewResult indxNull = (ViewResult)target.Index(null);

            // Act - get the set of states
            int res1 = ((LocationListViewModel)indx.Model).PagingInfo.TotalItems;
            int res2 = ((LocationListViewModel)indxIl.Model).PagingInfo.TotalItems;
            int res3 = ((LocationListViewModel)indxIn.Model).PagingInfo.TotalItems;
            int resAll = ((LocationListViewModel)indxNull.Model).PagingInfo.TotalItems;

            //Assert
            Assert.AreEqual(res1, 3);
            Assert.AreEqual(res2, 1);
            Assert.AreEqual(res3, 1);
            Assert.AreEqual(resAll, 5);

        }

        [TestMethod]
        public void Contains_All_Locations()
        {
            // Arrange - create the mock repository
            Mock<ILocationRepository> mock = new Mock<ILocationRepository>();
            mock.Setup(m => m.Locations).Returns(new List<Location>
             {
                 new Location {Id = 1, Name = "L1", State="MI" },
                 new Location {Id = 2, Name = "L2", State="IL"},
                 new Location {Id = 3, Name = "L3", State="MI"},
                 new Location {Id = 4, Name = "L4", State="IN"},
                 new Location {Id = 5, Name = "L5", State="MI"}

             });

            // Arrange
            LocationsController target = new LocationsController(mock.Object);
            ViewResult indx = (ViewResult)target.Index(null);
            //Action
            Location[] result = ((LocationListViewModel)indx.Model).Locations.ToArray();

            //Assert
            Assert.AreEqual(result.Length, 5);
            Assert.AreEqual("L1", result[0].Name);
            Assert.AreEqual("L2", result[1].Name);
            Assert.AreEqual("L3", result[2].Name);
        }
        [TestMethod]
        public void Can_Edit_Location()
        {
            // Arrange - create the mock repository
            Mock<ILocationRepository> mock = new Mock<ILocationRepository>();
            mock.Setup(m => m.Locations).Returns(new List<Location>
             {
                 new Location {Id = 1, Name = "L1", State="MI" },
                 new Location {Id = 2, Name = "L2", State="IL"},
                 new Location {Id = 3, Name = "L3", State="MI"},
                 new Location {Id = 4, Name = "L4", State="IN"},
                 new Location {Id = 5, Name = "L5", State="MI"}

             });

            // Arrange
            LocationsController target = new LocationsController(mock.Object);

            //Action
            Location l1 = target.Edit(1).ViewData.Model as Location;
            Location l2 = target.Edit(2).ViewData.Model as Location;
            Location l3 = target.Edit(3).ViewData.Model as Location;

            //Assert
            Assert.AreEqual(1, l1.Id);
            Assert.AreEqual(2, l2.Id);
            Assert.AreEqual(3, l3.Id);
        }
        [TestMethod]
        public void Cannot_Edit_Nonexistent_Location()
        {
            // Arrange - create the mock repository
            Mock<ILocationRepository> mock = new Mock<ILocationRepository>();
            mock.Setup(m => m.Locations).Returns(new List<Location>
             {
                 new Location {Id = 1, Name = "L1", State="MI" },
                 new Location {Id = 2, Name = "L2", State="IL"},
                 new Location {Id = 3, Name = "L3", State="MI"}

             });

            // Arrange
            LocationsController target = new LocationsController(mock.Object);

            //Action
            Location result = (Location)target.Edit(4).ViewData.Model;

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Can_Save_Valid_Changes_To_Location()
        {
            //Arrange - create mock repository
            Mock<ILocationRepository> mock = new Mock<ILocationRepository>();

            //Arrange - create the controller
            LocationsController target = new LocationsController(mock.Object);

            //Arrange - create a location
            Location loc = new Location { Id= 1, Name = "Test", Address1 = "123 N. Address", City = "Troy", Zip = "87654",State="AZ", };

            //Act - try to save the location
            ActionResult result = target.Edit(loc);

            //Assert - check that the repo was called
            mock.Verify(m => m.SaveLocation(loc));
            //Assert - check the method result type
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Cannot_Save_Invalid_Changes_To_Location()
        {
            //Arrange - create mock repository
            Mock<ILocationRepository> mock = new Mock<ILocationRepository>();

            //Arrange - create the controller
            LocationsController target = new LocationsController(mock.Object);

            //Arrange - create a location
            Location loc = new Location { Name = "Test" };

            //Arrange - add an error to the model state
            target.ModelState.AddModelError("error", "error");

            //Act - try to save the location
            ActionResult result = target.Edit(loc);

            //Assert - check that the repo was called
            mock.Verify(m => m.SaveLocation(It.IsAny<Location>()), Times.Never());
            //Assert - check the method result type
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }


        [TestMethod]
        public void Can_Delete_Valid_Locations()
        {
            //Arrange - create a location
            Location loc = new Location { Id = 2, Name = "Test", Address1 = "123 N. Address", City = "Troy", Zip = "87654" };

            // Arrange - create the mock repository
            Mock<ILocationRepository> mock = new Mock<ILocationRepository>();
            mock.Setup(m => m.Locations).Returns(new Location[]
            {
                new Location {Id = 1 , Name = "L1", Address1 = "123 N. Address", City = "Troy", Zip="87654" },
                loc,
                new Location {Id = 3 , Name = "L3" , Address1 = "123 N. Address", City = "Troy", Zip="87654" }
            });

            // Arrange - create the controller
            LocationsController target = new LocationsController(mock.Object);

            // Act - delete the product
            target.Delete(loc.Id);

            //Assert - ensure that the repository delete method was called with the correct location
            mock.Verify(m => m.DeleteLocation(loc.Id));

        }
        
    }
}
