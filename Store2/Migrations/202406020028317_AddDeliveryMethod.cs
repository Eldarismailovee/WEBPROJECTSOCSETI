﻿namespace Store2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeliveryMethod : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeliveryMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DeliveryMethods");
        }
    }
}
