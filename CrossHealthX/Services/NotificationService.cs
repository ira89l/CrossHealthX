namespace CrossHealthX.Services;

public class NotificationService
{
    public void ShowNotification(string message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            App.Current.MainPage.DisplayAlert("CrossHealthX", message, "OK");
        });
    }
}
