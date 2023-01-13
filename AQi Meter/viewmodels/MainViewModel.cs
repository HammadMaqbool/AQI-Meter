using CommunityToolkit.Mvvm.Input;
 using AQi_Meter.services;
using AQi_Meter.models;
using CommunityToolkit.Mvvm.ComponentModel;
using AQi_Meter.views;
using Microsoft.Maui.Controls;

namespace AQi_Meter.viewmodels;

public partial class MainViewModel : AqiBase
{
	[ObservableProperty]
	string btnText;

	[ObservableProperty]
	string dayWish;

    [ObservableProperty]
    string daywishImage;

    [ObservableProperty]
    string dateandtime;

    public MainViewModel()
	{
		Title = "AQI Meter";
		BtnText = "Check AQI";
		WishOfTheDay();
	}

	[RelayCommand]
	private async void Nav_toDetail()
	{
        Root getDeserializedData = new();
        ApiDataAccess apiDataAccess = new();
        IsBusy = true;
        BtnText = "Checking. . .";
        Coordinates coordinates = new();
        LocationAccess access = new();
        coordinates = await access.getCurrentLocation();
        if (coordinates is not null)
        {

            getDeserializedData = await apiDataAccess.getLocationAqi(coordinates.Longitutde, coordinates.Latitude);
            IsBusy = false;
            BtnText = "Check AQI";

            await Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object>
        {
            {
                "ApiAccessData" , getDeserializedData
            }
        });
        }
        else
        {
            IsBusy = false;
            await Shell.Current.DisplayAlert("Alert!", "Location not found", "OK");
        }
    }

	private void WishOfTheDay()
	{
        Dateandtime = DateTime.Now.ToLongDateString();

        //Times to Change the Wish
        DateTime morning = DateTime.Parse("6:00:00.000");
        DateTime afternoon = DateTime.Parse("13:00:00.000"); // 1:00pm 
        DateTime evening = DateTime.Parse("17:00:00.000"); // 5:00pm
        DateTime night = DateTime.Parse("21:00:00.000"); // 9:00 pm


		DateTime now= DateTime.Now;
        if(now > morning && now<afternoon)
        {
            DayWish = "Good Morning";
            DaywishImage = "sunset.gif";
        }
        else if (now > afternoon && now <evening)
        {
            DayWish = "Good Afternon";
            DaywishImage = "sun.gif";

        }
        else if(now > evening && now<night)
        {
            DayWish = "Good Evening";
            DaywishImage = "sunset.gif";

        }
        else if (now > night)
        {
            DayWish = "Good Night";
            DaywishImage = "nightcute.gif";

        }

    }
}
