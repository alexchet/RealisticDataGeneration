using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> Get();
    }
}
