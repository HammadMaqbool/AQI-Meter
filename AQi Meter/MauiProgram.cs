using AQi_Meter.viewmodels;
using AQi_Meter.views;
using Microsoft.Extensions.Logging;

namespace AQi_Meter;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		//Add Pages:
		builder.Services.AddSingleton<MainPage>();

        builder.Services.AddTransient<DetailPage>();

		//Add ViewModels
		builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<DetailViewModel>();


        //Services

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
