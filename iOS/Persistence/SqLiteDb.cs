using System;
using System.IO;
using ControlX.iOS.Persistence;
using ControlX.Persistence;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqLiteDb))]
namespace ControlX.iOS.Persistence
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
