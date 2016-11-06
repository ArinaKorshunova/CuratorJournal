using CuratorJournal.DataBase.Models;
using CuratorJournal.Logic.EnumWork;
using CuratorJournal.Logic.PasswordSecurity;

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

            if (!context.Users.Any())
            {
                User user = new User {
                    Login = "admin",
                    Password = Security.HashPassword("admin123")
                };
                context.Users.Add(user);
                context.SaveChanges();
            }

            if (!context.UserRoles.Any())
            {
                UserRole newUserRole = new UserRole
                {
                    RoleId = Role.Administrator.Id,
                    User = context.Users.Single(x => x.Login == "admin")
                };

                context.UserRoles.Add(newUserRole);
            }
        }
    }
}
