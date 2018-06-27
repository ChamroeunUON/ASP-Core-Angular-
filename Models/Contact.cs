using System.ComponentModel.DataAnnotations;

namespace ASP_Angular.Models
{
    public class Contact{
        [Required]
        [StringLength (255)]
        public string ContactName { get; set; }

        [StringLength (255)]
        public string ContactEmail { get; set; }

        [Required]
        [StringLength (255)]

        public string ContactPhone { get; set; }

    }
}