using AQi_Meter.models;
namespace AQi_Meter.services;

public class LocationAccess
{
    public async Task<Coordinates> getCurrentLocation()
    {
        Coordinates coordinates = new();
        if(Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
        {
            GeolocationRequest _request = new GeolocationRequest(GeolocationAccuracy.High,TimeSpan.FromSeconds(10));
            Location location = await Geolocation.Default.GetLocationAsync(_request);

            if (location != null)
            {
                coordinates.Longitutde = location.Longitude;
                coordinates.Latitude = location.Latitude;
            }

        }
        else
        {
            await Shell.Current.DisplayAlert("Connectivity","Internet Connecton not available","OK");
        }
        return coordinates;
    }
}
