namespace TicketDataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order_update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropColumn("dbo.Orders", "UserId");
            RenameColumn(table: "dbo.Orders", name: "User_Id", newName: "UserId");
            AddColumn("dbo.Orders", "IsFinalPay", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Orders", "Order_Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "AllPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Orders", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Orders", "UserId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "UserId" });
            AlterColumn("dbo.Orders", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "AllPrice", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Order_Date", c => c.String(nullable: false));
            DropColumn("dbo.Orders", "IsFinalPay");
            RenameColumn(table: "dbo.Orders", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "User_Id");
            AddForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
