namespace DX.Loan.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Add_CustomerInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerInfo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Area = c.String(),
                        Age = c.Int(),
                        IdCard = c.String(maxLength: 20),
                        Interest = c.Decimal(precision: 18, scale: 2),
                        DebitAmount = c.Decimal(precision: 18, scale: 2),
                        SesameScore = c.Int(),
                        CreditRating = c.String(maxLength: 30),
                        ApplicationDate = c.DateTime(),
                        Tel = c.String(maxLength: 40),
                        WeChat = c.String(maxLength: 60),
                        QQ = c.String(maxLength: 30),
                        AppEquipment = c.String(maxLength: 30),
                        Source = c.String(maxLength: 30),
                        TransTimes = c.Int(),
                        RecordCharge = c.Decimal(precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CustomerInfo_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerInfo",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CustomerInfo_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
