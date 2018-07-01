using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASP_Angular.Controllers.Resources;
using ASP_Angular.Core.Models;

namespace ASP_Angular.Core.Models
{
    public class Make{
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Model>  Models { get; set; }
        public Make()
        {
            Models = new Collection<Model>();
        }
    }
}