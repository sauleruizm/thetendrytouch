namespace Web.TendryTouch.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProducId = c.Int(nullable: false, identity: true),
                        Barcode = c.String(maxLength: 13, unicode: false, storeType: "nvarchar"),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        Created = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.ProducId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        StockId = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceSale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        QuantitySale = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false, precision: 0),
                        ProductId = c.Int(nullable: false),
                        Product_ProducId = c.Int(),
                    })
                .PrimaryKey(t => t.StockId)
                .ForeignKey("dbo.Products", t => t.Product_ProducId)
                .Index(t => t.Product_ProducId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stocks", "Product_ProducId", "dbo.Products");
            DropIndex("dbo.Stocks", new[] { "Product_ProducId" });
            DropTable("dbo.Stocks");
            DropTable("dbo.Products");
        }
    }
}
