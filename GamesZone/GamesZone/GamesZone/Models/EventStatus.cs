namespace GamesZone.Models
{
    public class EventStatus
    {
        public int event_status_id { get; set; }
        public string name { get; set; }
        public bool is_active { get; set; }
        public int quarter { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public int down { get; set; }
        public int yards_to_go { get; set; }
    }
}
