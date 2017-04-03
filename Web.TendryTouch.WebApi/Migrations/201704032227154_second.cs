namespace Web.TendryTouch.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.product", "CreatedDate", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.product", "CreatedBy", c => c.String(unicode: false));
            AddColumn("dbo.product", "ModifiedDate", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.product", "ModifiedBy", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.product", "ModifiedBy");
            DropColumn("dbo.product", "ModifiedDate");
            DropColumn("dbo.product", "CreatedBy");
            DropColumn("dbo.product", "CreatedDate");
        }
    }
}
