namespace ASP_Angular.Extensions {
    public interface IQueryObject {
        string SortBy { get; set; }
        bool IsSortByAccending { get; set; }
        int Page { get; set; }
        byte PageSize { set; get; }

    }
}