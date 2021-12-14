namespace Task1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUsernameInProductsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Username");
        }
    }
}
