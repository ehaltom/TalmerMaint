using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TalmerMaint.Domain.Abstract;
using TalmerMaint.Domain.Entities;
using TalmerMaint.WebUI.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace TalmerMaint.Tests
{
    [TestClass]
    public class ImageTests
    {
        [TestMethod]
        public void Can_Retrieve_Image_Data()
        {
            // Arrange - create a location with image data
            Location loc = new Location
            {
                Id = 2,
                Name = "Test"
            };

            // Arrange - create the mock repository
            Mock<ILocationRepository> mock = new Mock<ILocationRepository>();
            mock.Setup(m => m.Locations).Returns(new Location[]
            {
                new Location {Id=1, Name = "P1" },
                loc,
                new Location {Id=3, Name = "P3" }
            }.AsQueryable());

            // Arrange - create the controller
            LocImageController target = new LocImageController(mock.Object);

            // Act - call the GetImage action method
            ActionResult result = target.GetImage(2);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FileResult));
        }

        [TestMethod]
        public void Cannot_Retrieve_Image_Data_For_Invalid_Id()
        {
            // Arrange - create a location with image data


            // Arrange - create the mock repository
            Mock<ILocationRepository> mock = new Mock<ILocationRepository>();
            mock.Setup(m => m.Locations).Returns(new Location[]
            {
                new Location {Id=1, Name = "P1" },
                new Location {Id=2, Name = "P2" }
            }.AsQueryable());

            // Arrange - create the controller
            LocImageController target = new LocImageController(mock.Object);

            // Act - call the GetImage action method
            ActionResult result = target.GetImage(100);

            // Assert 
            Assert.IsNull(result);
        }
    }
}
