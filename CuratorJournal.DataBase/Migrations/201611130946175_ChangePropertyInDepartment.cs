namespace CuratorJournal.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePropertyInDepartment : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Departments", name: "DeanId", newName: "HeadOfDepartmentId");
            RenameColumn(table: "dbo.Departments", name: "HeadDepartmentId", newName: "MainDepartmentId");
            RenameIndex(table: "dbo.Departments", name: "IX_HeadDepartmentId", newName: "IX_MainDepartmentId");
            RenameIndex(table: "dbo.Departments", name: "IX_DeanId", newName: "IX_HeadOfDepartmentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Departments", name: "IX_HeadOfDepartmentId", newName: "IX_DeanId");
            RenameIndex(table: "dbo.Departments", name: "IX_MainDepartmentId", newName: "IX_HeadDepartmentId");
            RenameColumn(table: "dbo.Departments", name: "MainDepartmentId", newName: "HeadDepartmentId");
            RenameColumn(table: "dbo.Departments", name: "HeadOfDepartmentId", newName: "DeanId");
        }
    }
}
