sing System;
using Microsoft.Extensions.DependencyInjection;

namespace CrossHealthX;

public partial class App : Application
{
    public App(IServiceProvider services)
    {
        InitializeComponent();
        MainPage = services.GetRequiredService<AppShell>();
    }
}
