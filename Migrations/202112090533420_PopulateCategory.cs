namespace Task1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategory : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (CatName) VALUES ( 'Electronics')");
            Sql("INSERT INTO Categories (CatName) VALUES ( 'Farm')");
            Sql("INSERT INTO Categories (CatName) VALUES ('Home And Kitchen')");
        }
        
        public override void Down()
        {
        }
    }
}
