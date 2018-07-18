namespace ASP_Angular.Controllers.Resources
{
    public class VehicleFilterResource
    {
        public int? MakeId { get; set; }
        public int? ModelId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortByAccending { get; set; }
    }
}