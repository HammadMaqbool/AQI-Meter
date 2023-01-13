using Android.Media;
using AQi_Meter.models;
using AQi_Meter.viewmodels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AQi_Meter.viewmodels;

[QueryProperty("Root", "ApiAccessData")]
public partial class DetailViewModel : AqiBase
{

	[ObservableProperty]
	Root root;

	public DetailViewModel()
	{
		Title = "Detail Page";
	}
	


}
