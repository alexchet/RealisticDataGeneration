using Bogus;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication;
using WebApplication.Controllers;
using WebApplication.Services;
using Xunit;

namespace XUnitTestProject
{
    public class WeatherForecastControllerTest
    {
        [Fact]
        public async Task Get_Success_WeatherForecast()
        {
            // Arrange
            var weatherServiceMock = new Mock<IWeatherService>();
            weatherServiceMock.Setup(x => x.Get()).ReturnsAsync(await GetFakeWeatherForecast());
            var controller = new WeatherForecastController(weatherServiceMock.Object);

            // Act
            var actionResult = await controller.Get();

            // Assert
            Assert.NotNull(actionResult);

            OkObjectResult result = actionResult as OkObjectResult;
            Assert.NotNull(result);

            var model = Assert.IsAssignableFrom<IEnumerable<WeatherForecast>>(result.Value);
            Assert.Equal(5, model.Count());
        }

        private async Task<IEnumerable<WeatherForecast>> GetFakeWeatherForecast()
        {
            return new Faker<WeatherForecast>()
                .RuleFor(x => x.Date, x => x.Date.Recent())
                .RuleFor(x => x.Summary, x => x.Lorem.Word())
                .RuleFor(x => x.TemperatureC, x => x.Random.Int(-20, 55))
                .Generate(5);
        }
    }
}
