namespace Movies.Domain.Models
{
    public class WatchHistoryItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string MovieId { get; set; }
        public string MovieName { get; set; }
        public string StoppedTime { get; set; } = "00:00:00";
        public bool Watched { get; set; } = false;
    }
}
