using System.ComponentModel.DataAnnotations;

namespace ASP_Angular.Core.Models
{
    public class Feature
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}