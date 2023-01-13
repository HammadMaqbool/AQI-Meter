using Android.Graphics;
using AQi_Meter.viewmodels;


namespace AQi_Meter.views;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}


 
}