namespace Task1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryActiveOrNot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ActiveOrNot", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "ActiveOrNot");
        }
    }
}
