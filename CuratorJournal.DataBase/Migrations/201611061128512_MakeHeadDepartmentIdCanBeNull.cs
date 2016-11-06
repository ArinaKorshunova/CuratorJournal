namespace CuratorJournal.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeHeadDepartmentIdCanBeNull : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Departments", new[] { "HeadDepartmentId" });
            AlterColumn("dbo.Departments", "HeadDepartmentId", c => c.Long());
            AlterColumn("dbo.Persons", "Rank", c => c.String(nullable: false));
            CreateIndex("dbo.Departments", "HeadDepartmentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Departments", new[] { "HeadDepartmentId" });
            AlterColumn("dbo.Persons", "Rank", c => c.String());
            AlterColumn("dbo.Departments", "HeadDepartmentId", c => c.Long(nullable: false));
            CreateIndex("dbo.Departments", "HeadDepartmentId");
        }
    }
}
