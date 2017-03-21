namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        ListID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ListID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        TaskName = c.String(),
                        Description = c.String(),
                        IsComplete = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ListID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskID)
                .ForeignKey("dbo.Lists", t => t.ListID, cascadeDelete: true)
                .Index(t => t.ListID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ListID", "dbo.Lists");
            DropIndex("dbo.Tasks", new[] { "ListID" });
            DropTable("dbo.Tasks");
            DropTable("dbo.Lists");
        }
    }
}
