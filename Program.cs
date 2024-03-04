using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        IWeatherProvider weatherProvider = new WeatherProxy();

        while (true)
        {
            Console.Write("Enter a city name (e.g Tomsk) (or 'exit' for quit): ");
            string city = Console.ReadLine();

            if (city.ToLower() == "exit")
            {
                break;
            }

            string weather = await weatherProvider.GetWeatherAsync(city);
            Console.WriteLine($"Weather temperature in {city}: {weather}");
        }
    }
}
