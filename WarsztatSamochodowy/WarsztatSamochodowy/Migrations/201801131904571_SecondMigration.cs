namespace WarsztatSamochodowy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cars", "FirstName");
            DropColumn("dbo.Cars", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "LastName", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "FirstName", c => c.Int(nullable: false));
        }
    }
}
