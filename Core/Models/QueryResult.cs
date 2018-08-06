using System.Collections.Generic;

namespace ASP_Angular.Core.Models
{
    public class QueryResult<T>
    {
        public int TotalsItem { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}