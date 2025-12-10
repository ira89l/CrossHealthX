using Microsoft.Maui.Controls;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Maui;

namespace CrossHealthX.Views;

public class AnalysisPage : ContentPage
{
    public AnalysisPage()
    {
        BackgroundColor = Colors.White;

        var backButton = new ImageButton
        {
            Source = "back_recolored.png",
            HeightRequest = 28,
            BackgroundColor = Colors.Transparent
        };
        backButton.Clicked += async (s, e) => await Shell.Current.GoToAsync("..");

        var searchIcon = new Image
        {
            Source = "analysis_recolored.png",
            HeightRequest = 26,
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
                Text = "Health Analysis",
                FontSize = 22,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Colors.Black
            },
            1, 0
        );
        header.Children.Add(searchIcon, 2, 0);

        View CreateRow(string name, string value)
        {
            return new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width = GridLength.Star },
                    new ColumnDefinition{ Width = GridLength.Auto }
                },
                Padding = new Thickness(15, 12),
                Children =
                {
                    new Label { Text=name, FontSize=18, TextColor=Colors.Black },
                    new Label { Text=value, FontSize=18, TextColor=Colors.Gray, HorizontalOptions=LayoutOptions.End }
                }
            };
        }

        View Divider() => new BoxView
        {
            HeightRequest = 1,
            BackgroundColor = Color.FromHex("#E5E5E5")
        };

        var chartModel = new PlotModel { Title = "Weekly Health Trend" };
        var lineSeries = new LineSeries();
        lineSeries.Points.Add(new DataPoint(0, 70));
        lineSeries.Points.Add(new DataPoint(1, 75));
        lineSeries.Points.Add(new DataPoint(2, 78));
        lineSeries.Points.Add(new DataPoint(3, 72));
        lineSeries.Points.Add(new DataPoint(4, 68));
        lineSeries.Points.Add(new DataPoint(5, 74));
        chartModel.Series.Add(lineSeries);

        var chart = new PlotView
        {
            HeightRequest = 200,
            Model = chartModel
        };

        var chartCard = new Frame
        {
            Style = (Style)Application.Current.Resources["CardFrame"],
            Content = chart
        };

        Content = new ScrollView
        {
            Content = new VerticalStackLayout
            {
                Spacing = 0,
                Children =
                {
                    header,
                    Divider(),
                    CreateRow("Cholesterol", "182 mg/dL"),
                    Divider(),
                    CreateRow("Blood Pressure", "118/78"),
                    Divider(),
                    CreateRow("Glucose", "96 mg/dL"),
                    Divider(),
                    CreateRow("Heart Rate", "72 BPM"),
                    Divider(),

                    new Label
                    {
                        Text = "Health Trend",
                        FontSize = 20,
                        FontAttributes = FontAttributes.Bold,
                        Margin = new Thickness(20,25,0,5),
                        TextColor = Colors.Black
                    },

                    chartCard
                }
            }
        };
    }
}
