namespace WarsztatSamochodowy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "pracownicy_EmployeeId", "dbo.Employees");
            DropIndex("dbo.Cars", new[] { "pracownicy_EmployeeId" });
            AddColumn("dbo.Employees", "Role", c => c.String());
            DropColumn("dbo.Cars", "pracownicy_EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "pracownicy_EmployeeId", c => c.Int());
            DropColumn("dbo.Employees", "Role");
            CreateIndex("dbo.Cars", "pracownicy_EmployeeId");
            AddForeignKey("dbo.Cars", "pracownicy_EmployeeId", "dbo.Employees", "EmployeeId");
        }
    }
}
