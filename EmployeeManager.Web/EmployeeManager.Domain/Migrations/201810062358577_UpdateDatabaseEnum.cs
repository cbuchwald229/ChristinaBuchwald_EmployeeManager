namespace EmployeeManager.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabaseEnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "SalaryType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "SalaryType");
        }
    }
}
