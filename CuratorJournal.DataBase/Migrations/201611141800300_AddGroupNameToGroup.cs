namespace CuratorJournal.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroupNameToGroup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "GroupName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Groups", "GroupName");
        }
    }
}
