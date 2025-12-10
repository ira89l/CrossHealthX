using CrossHealthX.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;

namespace CrossHealthX;

public class AppShell : Shell
{
    private readonly IServiceProvider _services;

    public AppShell(IServiceProvider services)
    {
        _services = services;

        this.FlyoutBehavior = FlyoutBehavior.Disabled;

        // Реєстрація сторінок для навігації
        Routing.RegisterRoute(nameof(AnalysisPage), typeof(AnalysisPage));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));

        var tabs = new TabBar();

        // DASHBOARD TAB
        tabs.Items.Add(new Tab
        {
            Title = "Dashboard",
            Icon = "dashboard.png",
            Icon = "dashboard.png",
            Items =
            {
                new ShellContent
                {
                    Title = "Dashboard",
                    ContentTemplate = new DataTemplate(typeof(MainPage))
                    ContentTemplate = new DataTemplate(() => _services.GetRequiredService<MainPage>())
                }
            }
        });

        // ANALYSIS TAB
        tabs.Items.Add(new Tab
        {
            Title = "Analysis",
            Icon = "analysis.png",
            Icon = "analysis.png",
            Items =
            {
                new ShellContent
                {
                    Title = "Analysis",
                    ContentTemplate = new DataTemplate(typeof(AnalysisPage))
                    ContentTemplate = new DataTemplate(() => _services.GetRequiredService<AnalysisPage>())
                }
            }
        });

        // SETTINGS TAB
        tabs.Items.Add(new Tab
        {
            Title = "Settings",
            Icon = "settings.png",
            Icon = "settings.png",
            Items =
            {
                new ShellContent
                {
                    Title = "Settings",
                    ContentTemplate = new DataTemplate(typeof(SettingsPage))
                    ContentTemplate = new DataTemplate(() => _services.GetRequiredService<SettingsPage>())
                }
            }
        });

        Items.Add(tabs);
    }
}