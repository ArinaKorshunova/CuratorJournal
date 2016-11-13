namespace CuratorJournal.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Text;

    public partial class AddStoredProcedureFindPerson : DbMigration
    {
        public override void Up()
        {
            StringBuilder storedProcedureCode = new StringBuilder();

            storedProcedureCode.Append("create procedure dbo.FindPersonByNameAndRank" + Environment.NewLine);
            storedProcedureCode.Append("@NameAndRank nvarchar(255)" + Environment.NewLine);
            storedProcedureCode.Append("as" + Environment.NewLine);
            storedProcedureCode.Append("select * from Persons " + Environment.NewLine);
            storedProcedureCode.Append("where LastName + ' ' + FirstName + ' ' + MiddleName + ' (' + Rank + ')' like '%'+@NameAndRank+'%'" + Environment.NewLine);

            this.Sql(storedProcedureCode.ToString());
        }
        
        public override void Down()
        {
            this.Sql("drop procedure dbo.FindPersonByNameAndRank ");
        }
    }
}
