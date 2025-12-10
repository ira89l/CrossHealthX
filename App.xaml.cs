namespace CrossHealthX;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Запускаємо головну навігаційну оболонку
        MainPage = new AppShell();
    }
}
