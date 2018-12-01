namespace EmployeeManager.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoggingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Loggings",
                c => new
                    {
                        LoggingId = c.Guid(nullable: false),
                        ErrorDateTime = c.DateTime(nullable: false),
                        ErrorMessage = c.String(),
                        StackTrace = c.String(),
                    })
                .PrimaryKey(t => t.LoggingId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Loggings");
        }
    }
}
