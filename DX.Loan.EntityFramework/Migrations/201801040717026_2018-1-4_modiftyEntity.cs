namespace DX.Loan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201814_modiftyEntity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerInfo", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.CustomerInfo", "Area", c => c.String(maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerInfo", "Area", c => c.String());
            AlterColumn("dbo.CustomerInfo", "Name", c => c.String(nullable: false));
        }
    }
}
