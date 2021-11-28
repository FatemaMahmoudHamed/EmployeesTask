using Employees.Core.Entities;
using Employees.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;

namespace Employees.Infrastructure
{
    public class SeedData
    {
        private static DateTime now = DateTime.Now;

        private static bool IsDevelopment { get; set; } = true;

        /// <summary>
        /// Initialize the database.
        /// </summary>
        /// <param name="db">The database context.</param>
        /// <param name="isDevelopment">Determine if this is the development environment.</param>
        public static void Initialize(CommandDbContext db, bool isDevelopment)
        {

            if (db is null)
            {
                throw new ArgumentNullException(nameof(db));
            }

            IsDevelopment = isDevelopment;
            db.Employees.AddRange(CreatEmployees());
            db.SaveChanges();

        }


        private static Employee[] CreatEmployees()
        {
            var Employees = new List<Employee>();

            if (IsDevelopment)
            {
                var devEmployees = new[]
                {
                    new Employee
                    {
                        //Id = 1,//Guid.NewGuid(),
                        CreatedOn = now,
                        Name = "A",
                        Email="A",
                        Address="A",
                        Phone="A",
                        IsDeleted=false

                    },
                    new Employee
                    {
                        //Id=2,//Guid.NewGuid(),
                        CreatedOn = now,
                        Name = "B",
                        Email="A",
                        Address="A",
                        Phone="A",
                        IsDeleted=false
                    },
                    new Employee
                    {
                        //Id=3,//Guid.NewGuid(),
                        CreatedOn = now,
                        Name = "C",
                        Email="A",
                        Address="A",
                        Phone="A",
                        IsDeleted=false},
                    new Employee
                    {
                        //Id=4,//Guid.NewGuid(),
                        CreatedOn = now,
                        Name = "D",
                        Email="A",
                        Address="A",
                        Phone="A",
                        IsDeleted=false
                    },
                    new Employee
                    {
                        //Id=4,//Guid.NewGuid(),
                        CreatedOn = now,
                        Name = "D",
                        Email="A",
                        Address="A",
                        Phone="A",
                        IsDeleted=false
                    },
                    new Employee
                    {
                        //Id=5,//Guid.NewGuid(),
                        CreatedOn = now,
                        Name = "D",
                        Email="A",
                        Address="A",
                        Phone="A",
                        IsDeleted=false
                    },
                };

                Employees.AddRange(devEmployees);
            }

            return Employees.ToArray();
        }
    }
}
