using SQLite;
using CrossHealthX.Models;

namespace CrossHealthX.Services;

public class ActivityDatabase
{
    private readonly SQLiteAsyncConnection _database;

    public ActivityDatabase(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Activity>().ConfigureAwait(false);
    }

    public Task<List<Activity>> GetActivitiesAsync() =>
        _database.Table<Activity>().ToListAsync();

    public Task<int> SaveActivityAsync(Activity activity)
    {
        if (activity.Id != 0)
            return _database.UpdateAsync(activity);
        else
            return _database.InsertAsync(activity);
    }
}
