namespace ASP_Angular.Models
{
    public class Model
    {
        public int Id{set;get;}
        public string Name { get; set; } 
        public int MakeId { get; set; }
        public Make Make { get; set; }
    }   
}