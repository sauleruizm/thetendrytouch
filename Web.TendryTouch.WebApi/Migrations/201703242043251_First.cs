namespace Web.TendryTouch.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BarcodeHistory",
                c => new
                    {
                        BarcodeId = c.Int(nullable: false, identity: true),
                        Country = c.String(nullable: false, unicode: false),
                        TypeProduct = c.String(nullable: false, unicode: false),
                        CodeProduct = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.BarcodeId);
            
            CreateTable(
                "dbo.product",
                c => new
                    {
                        BarcodeId = c.Int(nullable: false),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        Created = c.DateTime(nullable: false, precision: 0),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceSale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BarcodeId)
                .ForeignKey("dbo.BarcodeHistory", t => t.BarcodeId)
                .Index(t => t.BarcodeId);
            
            CreateTable(
                "dbo.category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Product_BarcodeId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.product", t => t.Product_BarcodeId)
                .Index(t => t.Product_BarcodeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.category", "Product_BarcodeId", "dbo.product");
            DropForeignKey("dbo.product", "BarcodeId", "dbo.BarcodeHistory");
            DropIndex("dbo.category", new[] { "Product_BarcodeId" });
            DropIndex("dbo.product", new[] { "BarcodeId" });
            DropTable("dbo.category");
            DropTable("dbo.product");
            DropTable("dbo.BarcodeHistory");
        }
    }
}
