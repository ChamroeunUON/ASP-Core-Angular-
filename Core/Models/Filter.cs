namespace ASP_Angular.Core.Models
{
    public class VehicleQuery
    {
        public int? MakeId { get; set; }
        public int? ModelId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortByAccending { get; set; }
    }
}