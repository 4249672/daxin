namespace DX.Loan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180613 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Finance_Account",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        Advance = c.Decimal(precision: 18, scale: 2),
                        AdvanceForzen = c.Decimal(precision: 18, scale: 2),
                        Blance = c.Decimal(precision: 18, scale: 2),
                        BlanceFrozen = c.Decimal(precision: 18, scale: 2),
                        Level = c.String(maxLength: 20),
                        IsActive = c.Boolean(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Finance_Trade_Detail",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FinanceAccountId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        SerialNo = c.String(nullable: false, maxLength: 30),
                        TradeType = c.String(nullable: false, maxLength: 10),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RemarkSubmit = c.String(maxLength: 100),
                        RemarkAudit = c.String(maxLength: 100),
                        RefNo = c.String(maxLength: 30),
                        TradeParams = c.String(maxLength: 100),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrderNo = c.String(),
                        Status = c.String(),
                        OrderAmount = c.Decimal(precision: 18, scale: 2),
                        UserId = c.Long(nullable: false),
                        CustomerId = c.Long(nullable: false),
                        Name = c.String(maxLength: 20),
                        CustomerNo = c.String(maxLength: 30),
                        Area = c.String(maxLength: 60),
                        Age = c.Int(),
                        IdCard = c.String(maxLength: 20),
                        Interest = c.Decimal(precision: 18, scale: 2),
                        DebitAmount = c.Decimal(precision: 18, scale: 2),
                        SesameScore = c.Int(),
                        CreditRating = c.Int(),
                        ApplicationDate = c.DateTime(),
                        Tel = c.String(maxLength: 40),
                        WeChat = c.String(maxLength: 60),
                        QQ = c.String(maxLength: 30),
                        AppEquipment = c.String(maxLength: 30),
                        Source = c.String(maxLength: 30),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Order");
            DropTable("dbo.Finance_Trade_Detail");
            DropTable("dbo.Finance_Account");
        }
    }
}
