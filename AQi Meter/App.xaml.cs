using AQi_Meter.viewmodels;
using AQi_Meter.views;

namespace AQi_Meter;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
