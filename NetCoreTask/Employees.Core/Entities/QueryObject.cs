using System;

namespace Employees.Infrastructure.Entities
{
    public class QueryObject
    {
        public string SortBy { get; set; }

        public bool IsSortAscending { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }

    public class EmployeeQueryObject : QueryObject
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}