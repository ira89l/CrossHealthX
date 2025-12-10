using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using CrossHealthX.Services;
using CrossHealthX.Models;

namespace CrossHealthX.ViewModels;

public class ActivityViewModel : INotifyPropertyChanged
{
    private readonly ActivityDatabase _db;

    private int steps;
    private int calories;
    private double distance;

    public int Steps
    {
        get => steps;
        set { steps = value; OnPropertyChanged(); }
    }

    public int Calories
    {
        get => calories;
        set { calories = value; OnPropertyChanged(); }
    }

    public double Distance
    {
        get => distance;
        set { distance = value; OnPropertyChanged(); }
    }

    public ICommand AddStepsCommand { get; }
    public ICommand ShareCommand { get; }

    public ActivityViewModel(ActivityDatabase database)
    {
        _db = database;

        AddStepsCommand = new Command(async () => await AddStepsAsync());
        ShareCommand = new Command(async () => await ShareAsync());

        _ = LoadLatestActivityAsync();
    }

    private async Task LoadLatestActivityAsync()
    {
        var list = await _db.GetActivitiesAsync();
        var latest = list.LastOrDefault();

        if (latest is null) return;

        Steps = latest.Steps;
        Calories = latest.Calories;
        Distance = latest.Distance;
    }

    private async Task AddStepsAsync()
    {
        Steps += 100;
        Calories = (int)(Steps * 0.04);
        Distance = Math.Round(Steps * 0.0008, 2);

        await SaveActivityAsync();
    }

    private async Task SaveActivityAsync()
    {
        var activity = new Activity
        {
            Steps = Steps,
            Calories = Calories,
            Distance = Distance,
            Date = DateTime.Now
        };

        await _db.SaveActivityAsync(activity);

        // повідомляємо UI
        OnPropertyChanged(nameof(Steps));
        OnPropertyChanged(nameof(Calories));
        OnPropertyChanged(nameof(Distance));
    }

    private async Task ShareAsync()
    {
        await Share.Default.RequestAsync(new ShareTextRequest
        {
            Title = "CrossHealthX",
            Text = $"Today: {Steps} steps, {Calories} kcal, {Distance} km"
        });
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
