namespace CuratorJournal.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeUserForPersonOptional : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Persons", new[] { "UsereId" });
            AlterColumn("dbo.Persons", "UsereId", c => c.Long());
            CreateIndex("dbo.Persons", "UsereId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Persons", new[] { "UsereId" });
            AlterColumn("dbo.Persons", "UsereId", c => c.Long(nullable: false));
            CreateIndex("dbo.Persons", "UsereId");
        }
    }
}
