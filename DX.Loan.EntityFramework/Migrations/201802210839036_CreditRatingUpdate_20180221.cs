namespace DX.Loan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditRatingUpdate_20180221 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerInfo", "CreditRating", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerInfo", "CreditRating", c => c.String(maxLength: 30));
        }
    }
}
