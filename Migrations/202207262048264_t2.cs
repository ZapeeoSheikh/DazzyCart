﻿namespace DazzyCart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class t2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Url", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Url", c => c.String());
            AlterColumn("dbo.Products", "Image", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
        }
    }
}
