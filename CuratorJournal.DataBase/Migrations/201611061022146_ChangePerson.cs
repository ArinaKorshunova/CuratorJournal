namespace CuratorJournal.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePerson : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.People", newName: "Persons");
            AddColumn("dbo.Persons", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Persons", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Persons", "MiddleName", c => c.String());
            AddColumn("dbo.Persons", "DepartmentId", c => c.Long(nullable: false));
            CreateIndex("dbo.Persons", "DepartmentId");
            AddForeignKey("dbo.Persons", "DepartmentId", "dbo.Departments", "Id");
            DropColumn("dbo.Persons", "FIO");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Persons", "FIO", c => c.String());
            DropForeignKey("dbo.Persons", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Persons", new[] { "DepartmentId" });
            DropColumn("dbo.Persons", "DepartmentId");
            DropColumn("dbo.Persons", "MiddleName");
            DropColumn("dbo.Persons", "LastName");
            DropColumn("dbo.Persons", "FirstName");
            RenameTable(name: "dbo.Persons", newName: "People");
        }
    }
}
