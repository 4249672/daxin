namespace DX.Loan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180613 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerInfo", "BuyUserIds", c => c.String(maxLength: 2000));
            AddColumn("dbo.AbpUsers", "UserLevel", c => c.String());
            AlterColumn("dbo.AbpUsers", "EmailAddress", c => c.String(maxLength: 256));
            DropColumn("dbo.AbpUsers", "Name");
            DropColumn("dbo.AbpUsers", "Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AbpUsers", "Surname", c => c.String(nullable: false, maxLength: 32));
            AddColumn("dbo.AbpUsers", "Name", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.AbpUsers", "EmailAddress", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.AbpUsers", "UserLevel");
            DropColumn("dbo.CustomerInfo", "BuyUserIds");
        }
    }
}
