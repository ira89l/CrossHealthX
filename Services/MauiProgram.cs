using CrossHealthX.Services;
using CrossHealthX.ViewModels;
using CrossHealthX.Views;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace CrossHealthX;

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

        // SQLite
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "activity.db3");
        builder.Services.AddSingleton<ActivityDatabase>(_ => new ActivityDatabase(dbPath));

        // Services
        builder.Services.AddSingleton<LocationService>();
        builder.Services.AddSingleton<NotificationService>();

        // ViewModels
        builder.Services.AddSingleton<ActivityViewModel>();

        // Pages
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<AnalysisPage>();
        builder.Services.AddTransient<SettingsPage>();

        // Shell
        builder.Services.AddSingleton<AppShell>();

        return builder.Build();
    }
}
