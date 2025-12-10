using Microsoft.Maui.Controls;
using CrossHealthX.Views;

namespace CrossHealthX;

public class AppShell : Shell
{
    public AppShell()
    {
        this.FlyoutBehavior = FlyoutBehavior.Disabled;

        // Реєстрація сторінок для навігації
        Routing.RegisterRoute(nameof(AnalysisPage), typeof(AnalysisPage));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));

        var tabs = new TabBar();

        // DASHBOARD TAB
        tabs.Items.Add(new Tab
        {
            Title = "Dashboard",
            Icon = "dashboard_recolored.png",
            Items =
            {
                new ShellContent
                {
                    Title = "Dashboard",
                    ContentTemplate = new DataTemplate(typeof(MainPage))
                }
            }
        });

        // ANALYSIS TAB
        tabs.Items.Add(new Tab
        {
            Title = "Analysis",
            Icon = "analysis_recolored.png",
            Items =
            {
                new ShellContent
                {
                    Title = "Analysis",
                    ContentTemplate = new DataTemplate(typeof(AnalysisPage))
                }
            }
        });

        // SETTINGS TAB
        tabs.Items.Add(new Tab
        {
            Title = "Settings",
            Icon = "settings_recolored.png",
            Items =
            {
                new ShellContent
                {
                    Title = "Settings",
                    ContentTemplate = new DataTemplate(typeof(SettingsPage))
                }
            }
        });

        Items.Add(tabs);
    }
}
