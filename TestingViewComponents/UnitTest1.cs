using AppViewComponent.Models;
using AppViewComponent.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestingViewComponents
{
    public class UnitTest1
    {
        [Fact]
        public void TestSummary()
        {
            //Arrange
            var mock = new Mock<ICity>();

            mock.SetupGet(m => m.Cities).Returns(new List<City>
            {
                new City { Population= 100},
                new City{ Population= 200}
            });

            var view = new CitySummary(mock.Object);


            //Act

            ViewViewComponentResult result = view.Invoke(false) as ViewViewComponentResult;


            //Assert
            Assert.IsType(typeof(ViewCityModel), result.ViewData.Model);
            Assert.Equal(2, ((ViewCityModel)result.ViewData.Model).Cities);
            Assert.Equal(300, ((ViewCityModel)result.ViewData.Model).Population);
        }

        
    }
}
