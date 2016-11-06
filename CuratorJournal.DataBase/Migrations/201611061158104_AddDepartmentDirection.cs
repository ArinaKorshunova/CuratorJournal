namespace CuratorJournal.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmentDirection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Departments", "DirectionId", "dbo.Directions");
            DropForeignKey("dbo.Directions", "QualificationId", "dbo.Qualifications");
            DropIndex("dbo.Departments", new[] { "DirectionId" });
            DropIndex("dbo.Directions", new[] { "QualificationId" });
            CreateTable(
                "dbo.DepartmentDirections",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        QualificationId = c.Long(nullable: false),
                        DirectionId = c.Long(nullable: false),
                        DepartmentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Directions", t => t.DirectionId, cascadeDelete: true)
                .ForeignKey("dbo.Qualifications", t => t.QualificationId)
                .Index(t => t.QualificationId)
                .Index(t => t.DirectionId)
                .Index(t => t.DepartmentId);
            
            DropColumn("dbo.Departments", "DirectionId");
            DropColumn("dbo.Directions", "QualificationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Directions", "QualificationId", c => c.Long(nullable: false));
            AddColumn("dbo.Departments", "DirectionId", c => c.Long());
            DropForeignKey("dbo.DepartmentDirections", "QualificationId", "dbo.Qualifications");
            DropForeignKey("dbo.DepartmentDirections", "DirectionId", "dbo.Directions");
            DropForeignKey("dbo.DepartmentDirections", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.DepartmentDirections", new[] { "DepartmentId" });
            DropIndex("dbo.DepartmentDirections", new[] { "DirectionId" });
            DropIndex("dbo.DepartmentDirections", new[] { "QualificationId" });
            DropTable("dbo.DepartmentDirections");
            CreateIndex("dbo.Directions", "QualificationId");
            CreateIndex("dbo.Departments", "DirectionId");
            AddForeignKey("dbo.Directions", "QualificationId", "dbo.Qualifications", "Id");
            AddForeignKey("dbo.Departments", "DirectionId", "dbo.Directions", "Id");
        }
    }
}
