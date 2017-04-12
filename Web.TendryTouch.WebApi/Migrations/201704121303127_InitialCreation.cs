namespace Web.TendryTouch.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.product", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64, unicode: false, storeType: "nvarchar"),
                        Description = c.String(maxLength: 512, unicode: false, storeType: "nvarchar"),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceSale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Country = c.String(nullable: false, unicode: false),
                        TypeProduct = c.String(nullable: false, unicode: false),
                        CodeProduct = c.String(unicode: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        ModifiedDate = c.DateTime(nullable: false, precision: 0),
                        ModifiedBy = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.category", "Product_ProductId", "dbo.product");
            DropIndex("dbo.category", new[] { "Product_ProductId" });
            DropTable("dbo.product");
            DropTable("dbo.category");
        }
    }
}
