namespace CuratorJournal.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        HeadDepartmentId = c.Long(nullable: false),
                        DirectionId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Directions", t => t.DirectionId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.HeadDepartmentId)
                .Index(t => t.HeadDepartmentId)
                .Index(t => t.DirectionId);
            
            CreateTable(
                "dbo.Directions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        QualificationId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Qualifications", t => t.QualificationId)
                .Index(t => t.QualificationId);
            
            CreateTable(
                "dbo.Qualifications",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Name = c.String(),
                        RussianName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Name = c.String(),
                        RussianName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Cipher = c.String(),
                        СuratorId = c.Long(nullable: false),
                        HeadOfDepartmentId = c.Long(nullable: false),
                        DepartmentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.People", t => t.HeadOfDepartmentId)
                .ForeignKey("dbo.People", t => t.СuratorId)
                .Index(t => t.СuratorId)
                .Index(t => t.HeadOfDepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FIO = c.String(),
                        Rank = c.String(),
                        UsereId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UsereId)
                .Index(t => t.UsereId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        RoleId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Name = c.String(),
                        RussianName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Habitations",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Name = c.String(),
                        RussianName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Information",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Name = c.String(),
                        RussianName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentHabitations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StudentId = c.Long(nullable: false),
                        HabitationId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Habitations", t => t.HabitationId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.HabitationId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FIO = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        GenderId = c.Long(nullable: false),
                        IsTargetSet = c.Boolean(nullable: false),
                        IsOlympiad = c.Boolean(nullable: false),
                        IsGeneralCompetition = c.Boolean(nullable: false),
                        GroupId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.GenderId)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .Index(t => t.GenderId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.StudentInformations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StudentId = c.Long(nullable: false),
                        InformationId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Information", t => t.InformationId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.InformationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentInformations", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentInformations", "InformationId", "dbo.Information");
            DropForeignKey("dbo.StudentHabitations", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Students", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.StudentHabitations", "HabitationId", "dbo.Habitations");
            DropForeignKey("dbo.Groups", "СuratorId", "dbo.People");
            DropForeignKey("dbo.Groups", "HeadOfDepartmentId", "dbo.People");
            DropForeignKey("dbo.People", "UsereId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Groups", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "HeadDepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Directions", "QualificationId", "dbo.Qualifications");
            DropForeignKey("dbo.Departments", "DirectionId", "dbo.Directions");
            DropIndex("dbo.StudentInformations", new[] { "InformationId" });
            DropIndex("dbo.StudentInformations", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "GroupId" });
            DropIndex("dbo.Students", new[] { "GenderId" });
            DropIndex("dbo.StudentHabitations", new[] { "HabitationId" });
            DropIndex("dbo.StudentHabitations", new[] { "StudentId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.People", new[] { "UsereId" });
            DropIndex("dbo.Groups", new[] { "DepartmentId" });
            DropIndex("dbo.Groups", new[] { "HeadOfDepartmentId" });
            DropIndex("dbo.Groups", new[] { "СuratorId" });
            DropIndex("dbo.Directions", new[] { "QualificationId" });
            DropIndex("dbo.Departments", new[] { "DirectionId" });
            DropIndex("dbo.Departments", new[] { "HeadDepartmentId" });
            DropTable("dbo.StudentInformations");
            DropTable("dbo.Students");
            DropTable("dbo.StudentHabitations");
            DropTable("dbo.Information");
            DropTable("dbo.Habitations");
            DropTable("dbo.Roles");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.People");
            DropTable("dbo.Groups");
            DropTable("dbo.Genders");
            DropTable("dbo.Qualifications");
            DropTable("dbo.Directions");
            DropTable("dbo.Departments");
        }
    }
}
