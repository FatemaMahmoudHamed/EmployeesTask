
using System;

namespace Employees.Core.Entities
{
    public class Employee:BaseEntity<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
