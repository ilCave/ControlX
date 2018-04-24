using SQLite;
namespace ControlX.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
