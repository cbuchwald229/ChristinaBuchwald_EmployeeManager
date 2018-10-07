namespace EmployeeManager.Domain.Migrations
{
    using EmployeeManager.Domain.Entities;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeManager.Domain.EmployeeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmployeeManager.Domain.EmployeeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Employees.AddOrUpdate(x => x.EmployeeId,
                new Employee()
                {
                    EmployeeId = Guid.Parse("8a4c0e20-7357-42b8-8ae1-a1bc2b62b593"),
                    FirstName = "Christina",
                    MiddleName = "Meghan",
                    LastName = "Buchwald",
                    BirthDate = new DateTime(1985, 12, 3),
                    HireDate = new DateTime(2018, 2, 5),
                    Department = "Backoffice",
                    JobTitle = "Programming Intern",
                    Salary = 35000,
                    SalaryType = SalaryType.Annual,
                    AvailableHours = "8 to 5"
                });
        }
    }
}
