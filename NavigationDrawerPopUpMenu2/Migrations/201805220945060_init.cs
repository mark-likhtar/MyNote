namespace MyNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Notes", new[] { "User_Id" });
            AlterColumn("dbo.Notes", "User_Id", c => c.Int());
            CreateIndex("dbo.Notes", "User_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Notes", new[] { "User_Id" });
            AlterColumn("dbo.Notes", "User_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Notes", "User_Id");
        }
    }
}
