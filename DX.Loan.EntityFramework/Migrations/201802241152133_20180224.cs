namespace DX.Loan.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class _20180224 : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.CustomerInfo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
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
                        IsComplete = c.Int(),
                        TransTimes = c.Int(),
                        RecordCharge = c.Decimal(precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_CustomerInfo_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            DropColumn("dbo.CustomerInfo", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerInfo", "IsDeleted", c => c.Boolean(nullable: false));
            AlterTableAnnotations(
                "dbo.CustomerInfo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
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
                        IsComplete = c.Int(),
                        TransTimes = c.Int(),
                        RecordCharge = c.Decimal(precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_CustomerInfo_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
        }
    }
}
