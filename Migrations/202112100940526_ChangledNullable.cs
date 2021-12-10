namespace Task1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangledNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "ActiveOrNot", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "ActiveOrNot", c => c.Boolean());
        }
    }
}
