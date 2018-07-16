namespace DX.Loan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180716 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notice", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AlterColumn("dbo.Notice", "PublicDate", c => c.DateTime());
            DropColumn("dbo.Notice", "Important");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notice", "Important", c => c.Short(nullable: false));
            AlterColumn("dbo.Notice", "PublicDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Notice", "RowVersion");
        }
    }
}
