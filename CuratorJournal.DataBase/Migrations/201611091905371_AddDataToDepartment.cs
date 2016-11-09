namespace CuratorJournal.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToDepartment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "DeanId", c => c.Long());
            AddColumn("dbo.Departments", "Address", c => c.String());
            AddColumn("dbo.Departments", "PhoneNumber", c => c.String());
            AddColumn("dbo.Departments", "PostInformation", c => c.String());
            CreateIndex("dbo.Departments", "DeanId");
            AddForeignKey("dbo.Departments", "DeanId", "dbo.Persons", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "DeanId", "dbo.Persons");
            DropIndex("dbo.Departments", new[] { "DeanId" });
            DropColumn("dbo.Departments", "PostInformation");
            DropColumn("dbo.Departments", "PhoneNumber");
            DropColumn("dbo.Departments", "Address");
            DropColumn("dbo.Departments", "DeanId");
        }
    }
}
