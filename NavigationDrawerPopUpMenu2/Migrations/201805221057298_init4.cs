namespace MyNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notes", "User_Id", "dbo.Users");
            DropIndex("dbo.Notes", new[] { "User_Id" });
            AlterColumn("dbo.Notes", "User_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Notes", "User_Id");
            AddForeignKey("dbo.Notes", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "User_Id", "dbo.Users");
            DropIndex("dbo.Notes", new[] { "User_Id" });
            AlterColumn("dbo.Notes", "User_Id", c => c.Int());
            CreateIndex("dbo.Notes", "User_Id");
            AddForeignKey("dbo.Notes", "User_Id", "dbo.Users", "Id");
        }
    }
}
