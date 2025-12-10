using Microsoft.Maui.Controls;
using CrossHealthX.ViewModels;

namespace CrossHealthX.Views;

public class MainPage : ContentPage
{
    public MainPage(ActivityViewModel vm)
    {
        BindingContext = vm;
        BackgroundColor = Colors.White;

        // LOGO
        var logo = new Image
        {
            Source = "logo_recolored.png",
            HeightRequest = 70,
            HorizontalOptions = LayoutOptions.Center
        };

        var title = new Label
        {
            Text = "CrossHealthX",
            FontSize = 22,
            HorizontalOptions = LayoutOptions.Center,
            TextColor = Color.FromHex("#1A1A1A"),
            Margin = new Thickness(0, -10, 0, 10)
        };

        var stepsLabel = new Label
        {
            Style = (Style)Application.Current.Resources["TitleLarge"]
        };
        stepsLabel.SetBinding(Label.TextProperty, "Steps");

        var caloriesRow = new HorizontalStackLayout
        {
            Spacing = 8,
            Children =
            {
                new Image { Source="calories.png", HeightRequest=22 },
                new Label { FontSize=16, TextColor=Colors.Gray }
            }
        };
        caloriesRow.Children[1].SetBinding(Label.TextProperty, "Calories");

        var distanceRow = new HorizontalStackLayout
        {
            Spacing = 8,
            Children =
            {
                new Image { Source="distance_recolored.png", HeightRequest=22 },
                new Label { FontSize=16, TextColor=Colors.Gray }
            }
        };
        distanceRow.Children[1].SetBinding(Label.TextProperty, "Distance");

        var infoRow = new HorizontalStackLayout
        {
            Spacing = 30,
            HorizontalOptions = LayoutOptions.Center,
            Children = { caloriesRow, distanceRow }
        };

        var historyCard = new Frame
        {
            Style = (Style)Application.Current.Resources["CardFrame"],
            Content = new VerticalStackLayout
            {
                Spacing = 12,
                Children =
                {
                    new Label
                    {
                        Text = "Activity History",
                        FontSize = 18,
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Colors.Black
                    },
                    new Image
                    {
                        Source="chart.png",
                        HeightRequest = 160
                    }
                }
            }
        };

        var shareButton = new Button
        {
            Text = "Share",
            Style = (Style)Application.Current.Resources["PrimaryButton"]
        };

        Content = new ScrollView
        {
            Content = new VerticalStackLayout
            {
                Spacing = 25,
                Padding = new Thickness(20),
                Children =
                {
                    logo,
                    title,
                    stepsLabel,
                    infoRow,
                    historyCard,
                    shareButton
                }
            }
        };
    }
}
