namespace DX.Loan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180710 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        ShortTitle = c.String(maxLength: 50),
                        Important = c.Short(nullable: false),
                        Author = c.String(maxLength: 30),
                        Prior = c.Int(nullable: false),
                        Content = c.String(maxLength: 1000),
                        PublicDate = c.DateTime(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notice");
        }
    }
}
