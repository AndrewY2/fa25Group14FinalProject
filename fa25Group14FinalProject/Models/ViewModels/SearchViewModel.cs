using System.ComponentModel.DataAnnotations;

namespace fa25Group14FinalProject.ViewModels
{
    public class SearchViewModel
    {
        public string? Title { get; set; }
        public string? Authors { get; set; }
        public int? BookNumber { get; set; }

        public int? GenreID { get; set; }

        public bool InStockOnly { get; set; }

        public SortType SortOption { get; set; }

        public enum SortType
        {
            Title,
            Author,
            MostPopular,
            Newest,
            Oldest,
            HighestRated
        }
    }
}
