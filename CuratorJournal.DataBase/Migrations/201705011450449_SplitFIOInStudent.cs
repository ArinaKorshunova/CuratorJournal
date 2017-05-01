namespace CuratorJournal.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SplitFIOInStudent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Groups", "HeadOfDepartmentId", "dbo.Persons");
            AddColumn("dbo.Students", "LastName", c => c.String());
            AddColumn("dbo.Students", "FirstName", c => c.String());
            AddColumn("dbo.Students", "FatherName", c => c.String());
            AddForeignKey("dbo.Groups", "HeadOfDepartmentId", "dbo.Persons", "Id", cascadeDelete: true);
            DropColumn("dbo.Students", "FIO");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "FIO", c => c.String());
            DropForeignKey("dbo.Groups", "HeadOfDepartmentId", "dbo.Persons");
            DropColumn("dbo.Students", "FatherName");
            DropColumn("dbo.Students", "FirstName");
            DropColumn("dbo.Students", "LastName");
            AddForeignKey("dbo.Groups", "HeadOfDepartmentId", "dbo.Persons", "Id");
        }
    }
}
