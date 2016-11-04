using CuratorJournal.Logic.EnumWork;

namespace CuratorJournal.DataBase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CuratorJournal.DataBase.Models.DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CuratorJournal.DataBase.Models.DataBaseContext context)
        {
            context.PopulateRussianEnums();
        }
    }
}
