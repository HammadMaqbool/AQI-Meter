using AQi_Meter.viewmodels;

namespace AQi_Meter;

public partial class MainPage : ContentPage
{

    public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
	}
}

