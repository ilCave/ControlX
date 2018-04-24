using System;
using System.IO;
using ControlX.Droid.Persistence;
using ControlX.Persistence;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqLiteDb))]
namespace ControlX.Droid.Persistence
{
    public class SqLiteDb : ISQLiteDb
    {
        public SqLiteDb()
        {
        }

        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLiteDb.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}





