
namespace AQi_Meter.models;

public class Datum
{
    public double aqi { get; set; }
    public double co { get; set; }
    public double mold_level { get; set; }
    public double no2 { get; set; }
    public double o3 { get; set; }
    public double pm10 { get; set; }
    public double pm25 { get; set; }
    public double pollen_level_grass { get; set; }
    public double pollen_level_tree { get; set; }
    public double pollen_level_weed { get; set; }
    public string predominant_pollen_type { get; set; }
    public double so2 { get; set; }
}

public class Root
{
    public string city_name { get; set; }
    public string country_code { get; set; }
    public List<Datum> data { get; set; }
    public double lat { get; set; }
    public double lon { get; set; }
    public string state_code { get; set; }
    public string timezone { get; set; }
}

//// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
