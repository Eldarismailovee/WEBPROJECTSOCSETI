namespace Store2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Products", name: "Category_Id", newName: "CategoryId");
            DropPrimaryKey("dbo.Categories");
            AddColumn("dbo.Categories", "CategoryId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Categories", "CategoryId");
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            DropColumn("dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Products", "CategoryId", c => c.Int());
            DropColumn("dbo.Categories", "CategoryId");
            AddPrimaryKey("dbo.Categories", "Id");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Products", "Category_Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
