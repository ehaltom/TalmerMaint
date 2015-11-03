using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TalmerMaint.WebUI.Infrastructure;
using System.Web.Mvc;
using Moq;
using TalmerMaint.WebUI.Models;
using TalmerMaint.WebUI.Controllers;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace TalmerMaint.Tests
{
    /// <summary>
    /// Summary description for Authentication
    /// </summary>
    [TestClass]
    public class Authentication
    {
        

        [TestMethod]
        public void Can_Login_With_Valid_Creds()
        {
            // Arrange - create a mock authenication provider
            
        }
    }
}
