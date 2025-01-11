namespace Domain.DTOs
{
    public class DashboardSummaryDTO
    {
        public int TotalBooks { get; set; }
        public decimal AverageRating { get; set; }
        public List<GenreSummaryDTO> ?BooksByGenre { get; set; }
    }
}