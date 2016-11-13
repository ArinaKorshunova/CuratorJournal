namespace CuratorJournal.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDepartmentInPersonOptional : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Persons", new[] { "DepartmentId" });
            AlterColumn("dbo.Persons", "DepartmentId", c => c.Long());
            CreateIndex("dbo.Persons", "DepartmentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Persons", new[] { "DepartmentId" });
            AlterColumn("dbo.Persons", "DepartmentId", c => c.Long(nullable: false));
            CreateIndex("dbo.Persons", "DepartmentId");
        }
    }
}
