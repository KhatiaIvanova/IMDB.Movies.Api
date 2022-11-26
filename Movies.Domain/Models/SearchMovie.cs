namespace Movies.Domain.Models;

public class SearchMovie
{
    public string SearchType { get; set; }
    public string Expression { get; set; }
    public List<SearchResponse> Results { get; set; }
    public string ErrorMessage { get; set; }


    public class SearchResponse
    {
        public string Id { get; set; }
        public string ResultType { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
