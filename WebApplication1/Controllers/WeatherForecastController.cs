using Microsoft.AspNetCore.Mvc;
// here we are using the library

namespace WebApplication1.Controllers
// here we are using the above namespace for public class below

{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    // ControllerBase is a base class provided by asp.net core
    // Controller is used to process incoming requests and returning proper responses
    {
        private static readonly string[] Summaries = new[]
        //here an array of strings is created named summaries which cannot be modified (readonly)
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        // GetWeatherForecast should handle get requests 
        public IEnumerable<WeatherForecast> Get()
        // Get the weatherforecast data and returns the response
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
            /* 
            Returns addition of current date,time and number from above sequence
            Returns random temperature from -20 to 55 range
            Returns random summary from summaries array
            */
               
        }
    }
}