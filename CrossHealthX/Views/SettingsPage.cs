using Microsoft.Maui.Controls;

namespace CrossHealthX.Views;

public class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        BackgroundColor = Colors.White;

        var backButton = new ImageButton
        {
            Source = "back_recolored.png",
            HeightRequest = 28,
            BackgroundColor = Colors.Transparent
        };
        backButton.Clicked += async (s, e) => await Shell.Current.GoToAsync("..");

        var settingsIcon = new Image
        {
            Source = "settings_recolored.png",
            HeightRequest = 30,
            HorizontalOptions = LayoutOptions.End
        };

        var header = new Grid
        {
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = GridLength.Auto },
                new ColumnDefinition { Width = GridLength.Star },
                new ColumnDefinition { Width = GridLength.Auto }
            },
            Padding = new Thickness(15, 15, 15, 10)
        };

        header.Children.Add(backButton, 0, 0);
        header.Children.Add(
            new Label
            {
                Text = "Settings",
                FontSize = 22,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Colors.Black
            },
            1, 0
        );
        header.Children.Add(settingsIcon, 2, 0);

        View CreateRow(string text, View right = null)
        {
            var row = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width = GridLength.Star },
                    new ColumnDefinition{ Width = GridLength.Auto }
                },
                Padding = new Thickness(15, 10)
            };

            row.Children.Add(new Label { Text=text, FontSize=18, TextColor=Colors.Black }, 0, 0);

            if (right != null)
                row.Children.Add(right, 1, 0);

            return row;
        }

        View Divider() => new BoxView
        {
            BackgroundColor = Color.FromHex("#E5E5E5"),
            HeightRequest = 1
        };

        var notifSwitch = new Switch { OnColor = Color.FromHex("#3AA8F4") };

        Content = new ScrollView
        {
            Content = new VerticalStackLayout
            {
                Children =
                {
                    header,
                    Divider(),
                    CreateRow("Notifications", notifSwitch),
                    Divider(),
                    CreateRow("Units", new Label { Text="Metric >", TextColor=Colors.Gray, FontSize=18 }),
                    Divider(),
                    CreateRow("Activity Level", new Label { Text="Moderate >", TextColor=Colors.Gray, FontSize=18 }),
                    Divider(),
                    CreateRow("Log Out", null)
                }
            }
        };
    }
}
