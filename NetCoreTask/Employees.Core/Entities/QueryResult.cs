using System.Collections.Generic;

namespace Employees.Core.Entities
{
    public class QueryResult<T>
    {
        public int TotalItems { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
