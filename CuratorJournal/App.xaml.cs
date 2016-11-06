using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CuratorJournal.DataBase.Models;

namespace CuratorJournal
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataBaseContext>());

            base.OnStartup(e);
        }
    }
}
