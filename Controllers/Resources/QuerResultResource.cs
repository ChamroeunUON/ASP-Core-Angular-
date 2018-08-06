using System.Collections.Generic;

namespace ASP_Angular.Controllers.Resources {
    public class QuerResultResource<T> {
        public int TotalsItem { get; set; }
        public IEnumerable<T> Items { get; set; }

    }
}