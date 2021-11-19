using Microsoft.AspNetCore.Mvc;
using ModellenBureau.Controllers;
using ModellenBureau.Models;
using System;
using Xunit;

namespace MissUniverseVerkiezingen
{
    public class HomeControllerTests
    {
        [Fact]
        public void Test_Index_NotNull()
        {
            HomeController ctrl = new HomeController();
            var result = ctrl.Index();

            Assert.NotNull(result);
        }
        [Fact]
        public void Test_Index_IsPersonViewModel()
        {
            HomeController ctrl = new HomeController();
            var result = ctrl.Index() as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<PersonViewModel>(result.Model);
        }
    }
}
