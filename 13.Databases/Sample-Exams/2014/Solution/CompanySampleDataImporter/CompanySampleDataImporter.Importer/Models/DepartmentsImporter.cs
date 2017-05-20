using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanySampleDataImporter.Data;

namespace CompanySampleDataImporter.Importer
{
    public class DepartmentsImporter : IImporter
    {
        private const int numberOfDepartments = 100;

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    for (int i = 0; i < numberOfDepartments; i++)
                    {
                        db.Departments.Add(new Department
                        {
                            Name = RandomGenerator.GetRandomString(10, 50)
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
            get { return $@"Importing Departments"; }
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
