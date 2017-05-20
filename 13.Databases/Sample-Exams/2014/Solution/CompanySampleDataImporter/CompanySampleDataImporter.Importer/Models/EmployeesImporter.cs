using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanySampleDataImporter.Data;

namespace CompanySampleDataImporter.Importer.Models
{
    public class EmployeesImporter : IImporter
    {
        private const int numberOfEmployees = 500;

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    var department = db
                    .Departments
                    .Select(d => d.Id)
                    .ToList();

                    for (int i = 0; i < numberOfEmployees; i++)
                    {
                        var randomDepartments = RandomGenerator.GetRandomNumber(0, department.Count - 1);
                        var randomDepartmentId = department[randomDepartments];
                        var managerID = randomDepartmentId;

                        db.Employees.Add(new Employee
                        {
                            FirstName = RandomGenerator.GetRandomString(39, 51),
                            LastName = RandomGenerator.GetRandomString(39, 51),
                            YearSalary = RandomGenerator.GetRandomNumber(50000, 200000),
                            ManagerId = managerID,
                            DepartmentId = randomDepartmentId
                        });

                        if (i % 10 == 0)
                        {
                            tr.Write(".");
                        }

                        if(i%100 == 0)
                        {
                            db.SaveChanges();
                            db.Dispose();
                            db = new CompanyEntities();
                        }
                    }

                    db.SaveChanges();
                };
            }
        }

        public string Message
        {
            get { return $@"Importing Employees"; }
        }

        public int Order
        {
            get { return 2; }
        }
    }
}
