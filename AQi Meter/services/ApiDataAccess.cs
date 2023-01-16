using AQi_Meter.models;
using Newtonsoft.Json;

namespace AQi_Meter.services;

public class ApiDataAccess
{
    /*
        Step 1: Create an account on RapidApi site (Free)
        strep 2: Subscribe to https://rapidapi.com/weatherbit/api/air-quality/ 
        Get Your own Rapid API Key & ApiHost Values and Assign to the relevant variables 
        declare below.
     */
    string RapidAPIKey = "7c2cef3882mshef8b1144463528fp190447jsn36be843492e2";
    string RapidAPIHost = "air-quality.p.rapidapi.com";

    public  async Task<Root> getLocationAqi(double Longitude, double Latitude)
    {
        Root getData = new();
        double lat = Latitude;
        double lon = Longitude;
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://air-quality.p.rapidapi.com/current/airquality?lon={lon}&lat={lat}"),
            Headers =
            {
        { "X-RapidAPI-Key", RapidAPIKey },
        { "X-RapidAPI-Host", RapidAPIHost },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            getData =  JsonConvert.DeserializeObject<Root>(body);
            //Console.WriteLine(body);
        }

        return getData;
    }
}
