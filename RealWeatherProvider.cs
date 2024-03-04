using Newtonsoft.Json;

public class RealWeatherProvider : IWeatherProvider
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "8962d947804f31c0210f152c8928d11e";
    private readonly GeocoderAPI _geocoder;

    public RealWeatherProvider()
    {
        _httpClient = new HttpClient();
        _geocoder = new GeocoderAPI(_httpClient, _apiKey);
    }

    public async Task<string> GetWeatherAsync(string city)
    {
        var coordinates = await GetCoordinates(city);

        string url = $"https://api.openweathermap.org/data/2.5/weather?lat={coordinates[0]}&lon={coordinates[1]}&units=metric&appid={_apiKey}";
        var response = await _httpClient.GetAsync(url);
        var jsonContent = await response.Content.ReadAsStringAsync();
        var dataTemp = JsonConvert.DeserializeObject<OpenWeatherData>(jsonContent);
        return dataTemp.main.temp.ToString();
    }

    private async Task<List<string>> GetCoordinates(string city)
    {
        await _geocoder.Get(city);
        var jsonContent = _geocoder.Content;
        var response = JsonConvert.DeserializeObject<List<GeocoderData>>(jsonContent);
        return [response[0].lat, response[0].lon];
    }
}
