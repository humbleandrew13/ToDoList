namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madeDateTimeinListpublic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lists", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lists", "Date");
        }
    }
}
