namespace DX.Loan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180223 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerInfo", "CustomerNo", c => c.String(maxLength: 30));
            AddColumn("dbo.CustomerInfo", "IsComplete", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerInfo", "IsComplete");
            DropColumn("dbo.CustomerInfo", "CustomerNo");
        }
    }
}
