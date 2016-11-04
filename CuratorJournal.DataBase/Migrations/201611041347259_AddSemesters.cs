namespace CuratorJournal.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSemesters : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Name = c.String(),
                        RussianName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.StudentSubjects", "SemesterId", c => c.Long(nullable: false));
            AddColumn("dbo.StudentSubjects", "Year", c => c.String());
            CreateIndex("dbo.StudentSubjects", "SemesterId");
            AddForeignKey("dbo.StudentSubjects", "SemesterId", "dbo.Semesters", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentSubjects", "SemesterId", "dbo.Semesters");
            DropIndex("dbo.StudentSubjects", new[] { "SemesterId" });
            DropColumn("dbo.StudentSubjects", "Year");
            DropColumn("dbo.StudentSubjects", "SemesterId");
            DropTable("dbo.Semesters");
        }
    }
}
