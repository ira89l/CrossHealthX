using CrossHealthX.Models;
using CrossHealthX.Services;
using OxyPlot;
using OxyPlot.Series;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CrossHealthX.ViewModels;

public class StatsViewModel : INotifyPropertyChanged
{
    private readonly ActivityDatabase _database;

    private PlotModel _activityPlot;
    public PlotModel ActivityPlot
    {
        get => _activityPlot;
        set { _activityPlot = value; OnPropertyChanged(); }
    }

    public StatsViewModel(ActivityDatabase db)
    {
        _database = db;
        _ = LoadChartAsync();
    }

    private async Task LoadChartAsync()
    {
        var activities = await _database.GetActivitiesAsync();

        // Якщо немає даних – демонстраційні точки
        if (activities.Count == 0)
        {
            activities = new List<Activity>
            {
                new Activity { Steps = 5000 },
                new Activity { Steps = 6500 },
                new Activity { Steps = 7800 },
                new Activity { Steps = 8200 },
                new Activity { Steps = 9100 }
            };
        }

        var model = new PlotModel { Title = "Activity Stats" };
        var series = new LineSeries();

        int index = 0;
        foreach (var activity in activities)
            series.Points.Add(new DataPoint(index++, activity.Steps));

        model.Series.Add(series);
        ActivityPlot = model;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
