using CommunityToolkit.Mvvm.Input;
using AQi_Meter.services;
using AQi_Meter.models;
using CommunityToolkit.Mvvm.ComponentModel;
using AQi_Meter.views;
using Microsoft.Maui.Controls;

namespace AQi_Meter.viewmodels;
{
    public partial class MainViewModel : AqiBase
    {
        // Observable Property for button text
        [ObservableProperty]
        string btnText;

        // Observable Property for day wish text
        [ObservableProperty]
        string dayWish;

        // Observable Property for day wish image
        [ObservableProperty]
        string daywishImage;

        // Observable Property for date and time
        [ObservableProperty]
        string dateandtime;

        public MainViewModel()
        {
            Title = "AQI Meter";
            BtnText = "Check AQI";
            WishOfTheDay();
        }

        // RelayCommand for navigation to detail page
        [RelayCommand]
        private async void Nav_toDetail()
        {
            // Creating new objects
            Root getDeserializedData = new();
            ApiDataAccess apiDataAccess = new();
            IsBusy = true;
            BtnText = "Checking. . .";
            Coordinates coordinates = new();
            LocationAccess access = new();

            // Getting current location
            coordinates = await access.getCurrentLocation();

            // If location is found
            if (coordinates is not null)
            {
                // Getting AQI data for location
                getDeserializedData = await apiDataAccess.getLocationAqi(coordinates.Longitutde, coordinates.Latitude);

                // Updating properties
                IsBusy = false;
                BtnText = "Check AQI";

                // Navigating to detail page
                await Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object>
                {
                    {
                        "ApiAccessData" , getDeserializedData
                    }
                });
            }
            else
            {
                // If location not found
                IsBusy = false;
                await Shell.Current.DisplayAlert("Alert!", "Location not found", "OK");
            }
        }

        // Function to get wish of the day
        private void WishOfTheDay()
        {
            Dateandtime = DateTime.Now.ToLongDateString();

            // Times to change the wish
            DateTime morning = DateTime.Parse("6:00:00.000");
            DateTime afternoon = DateTime.Parse("13:00:00.000"); // 1:00pm 
            DateTime evening = DateTime.Parse("17:00:00.000"); // 5:00pm
            DateTime night = DateTime.Parse("21:00:00.000"); // 9:00 pm

            DateTime now= DateTime.Now;

            // Setting the wish based on the time
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

       
        
