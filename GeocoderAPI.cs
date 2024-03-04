public class GeocoderAPI(HttpClient httpClient, string apiKey)
{
    private readonly string _apiKey = apiKey;
    private readonly HttpClient _httpClient = httpClient;

    public string Content { get; private set; }

    public async Task Get(string city)
    {
        string url = $"http://api.openweathermap.org/geo/1.0/direct?q={city}&limit=1&appid={_apiKey}";
        var response = await _httpClient.GetAsync(url);
        Content = await response.Content.ReadAsStringAsync();
    }
}
