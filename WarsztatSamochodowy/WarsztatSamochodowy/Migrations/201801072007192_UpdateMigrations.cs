namespace WarsztatSamochodowy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMigrations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "FirstName", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "LastName", c => c.Int(nullable: false));
            DropColumn("dbo.Cars", "ResponsiblePerson");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "ResponsiblePerson", c => c.String());
            DropColumn("dbo.Cars", "LastName");
            DropColumn("dbo.Cars", "FirstName");
        }
    }
}
