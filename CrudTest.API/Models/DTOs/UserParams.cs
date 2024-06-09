namespace CrudTest.API.Models.DTOs
{
    public class UserParams
    {        
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;     
        public string Sort { get; set; }
        public string SortType { get; set; } = "asc";
        public string Search { get; set; }
      
    }
}
