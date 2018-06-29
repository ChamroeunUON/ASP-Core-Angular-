using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASP_Angular.Controllers.Resources;

namespace ASP_Angular.Models
{
    public class Make{
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Model>  Models { get; set; }
        public Make()
        {
            Models = new Collection<Model>();
        }

        internal object Select(Func<object, MakeResource> p)
        {
            throw new NotImplementedException();
        }
    }
}