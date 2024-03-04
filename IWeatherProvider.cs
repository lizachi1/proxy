public interface IWeatherProvider
{
    Task<string> GetWeatherAsync(string city);
}
