using System;
using ControlX.Persistence;
using Xamarin.Forms;

namespace ControlX
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl ="http://controlx.docsmarshal.it"; //"http://192.168.8.95/DocsMarshalPortal"; //
        public static string StaticSessionId = "2b0664f2-aff9-4d8c-af92-e35659530fe4";
        public static string CurTitle = "Controlx";
        public static string CurLang = "IT";



        public App()
        {
            InitializeComponent();
            ConnectAndCreateSqlDb();
            DependencyService.Register<Services.ControlXOrchestrator>();
            MainPage = new NavigationPage(new Views.WelcomeV());
        }

        private void ConnectAndCreateSqlDb()
        {
            var _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _connection.CreateTableAsync<Models.Contatto>();
        }
    }
}
