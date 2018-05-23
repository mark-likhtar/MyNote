namespace MyNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notices", "User_Id", "dbo.Users");
            DropIndex("dbo.Notices", new[] { "User_Id" });
            AlterColumn("dbo.Notices", "User_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Notices", "User_Id");
            AddForeignKey("dbo.Notices", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notices", "User_Id", "dbo.Users");
            DropIndex("dbo.Notices", new[] { "User_Id" });
            AlterColumn("dbo.Notices", "User_Id", c => c.Int());
            CreateIndex("dbo.Notices", "User_Id");
            AddForeignKey("dbo.Notices", "User_Id", "dbo.Users", "Id");
        }
    }
}
