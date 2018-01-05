namespace WarsztatSamochodowy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "pracownicy_EmployeeId", "dbo.Employees");
            DropIndex("dbo.Cars", new[] { "pracownicy_EmployeeId" });
            RenameColumn(table: "dbo.Cars", name: "pracownicy_EmployeeId", newName: "EmployeeId");
            AddColumn("dbo.Employees", "Role", c => c.String());
            AlterColumn("dbo.Cars", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "EmployeeId");
            AddForeignKey("dbo.Cars", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Cars", new[] { "EmployeeId" });
            AlterColumn("dbo.Cars", "EmployeeId", c => c.Int());
            DropColumn("dbo.Employees", "Role");
            RenameColumn(table: "dbo.Cars", name: "EmployeeId", newName: "pracownicy_EmployeeId");
            CreateIndex("dbo.Cars", "pracownicy_EmployeeId");
            AddForeignKey("dbo.Cars", "pracownicy_EmployeeId", "dbo.Employees", "EmployeeId");
        }
    }
}
