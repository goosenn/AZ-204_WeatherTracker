using Newtonsoft.Json;
using RestSharp;
using WeatherTracker.Models;

namespace WeatherTracker.Data
{
    public class WeatherForecastService
    {
        private readonly IConfiguration configuration;

        public WeatherForecastService(IConfiguration config)
        {
            configuration = config;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<ForcastResponse> GetForecastAsync(ForcastRequest forcast)
        {
            var WeatherApiKey = "8e01d6817288451b9e9190425232310";
            var WeatherApiUri = "https://api.weatherapi.com/v1/forecast.json?";
            var client = new RestClient(String.Concat(WeatherApiUri, "key=", WeatherApiKey, "&q=",forcast.Location,"&days=",forcast.Days,"&aqi=no&alerts=no"));
            var request = new RestRequest();
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return Task.FromResult(JsonConvert.DeserializeObject<ForcastResponse>(response.Content));

            //return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = startDate.AddDays(index),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //}).ToArray());
        }


    }
}