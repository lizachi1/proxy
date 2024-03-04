public class WeatherProxy : IWeatherProvider
{
    private readonly Dictionary<string, string> _cache = new ();
    private readonly RealWeatherProvider _realWeatherProvider = new ();

    public async Task<string> GetWeatherAsync(string city)
    {
        if (!_cache.ContainsKey(city))
        {
            Console.WriteLine("Bringing data from API");
            string weather = await _realWeatherProvider.GetWeatherAsync(city);
            _cache[city] = weather;
        }
        else
        {
            Console.WriteLine("Data has found in cache");
        }
        return _cache[city];
    }
}
