using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CuratorJournal.DataBase.Models;
using System.Windows.Navigation;
using CuratorJournal.View;

namespace CuratorJournal
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private NavigationWindow navigationWindow;

        protected override void OnStartup(StartupEventArgs e)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataBaseContext>());

            base.OnStartup(e);
        }


        private void Application_Startup(object sender, StartupEventArgs e)
        {

            navigationWindow = new NavigationWindow();
            navigationWindow.Height = 850;
            navigationWindow.Width = 1200;
            var page = new Autorization();
            navigationWindow.Navigate(page);
            navigationWindow.Show();
        }
    }
}
