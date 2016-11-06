namespace CuratorJournal.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDirectionIdInDepartmentOptional : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Departments", "DirectionId", "dbo.Directions");
            DropIndex("dbo.Departments", new[] { "DirectionId" });
            AlterColumn("dbo.Departments", "DirectionId", c => c.Long());
            CreateIndex("dbo.Departments", "DirectionId");
            AddForeignKey("dbo.Departments", "DirectionId", "dbo.Directions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "DirectionId", "dbo.Directions");
            DropIndex("dbo.Departments", new[] { "DirectionId" });
            AlterColumn("dbo.Departments", "DirectionId", c => c.Long(nullable: false));
            CreateIndex("dbo.Departments", "DirectionId");
            AddForeignKey("dbo.Departments", "DirectionId", "dbo.Directions", "Id", cascadeDelete: true);
        }
    }
}
