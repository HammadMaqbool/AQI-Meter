using AQi_Meter.views;

namespace AQi_Meter;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
    }
}
