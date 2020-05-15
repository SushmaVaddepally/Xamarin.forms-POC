namespace GamesZone.Models
{
    using System;
    using System.Text;

    public class Game
    {
        public int game_id { get; set; }
        public DateTime date_start { get; set; }
        public int game_number { get; set; }
        public int week { get; set; }
        public int season { get; set; }
        public int attendance { get; set; }
        public object game_duration { get; set; }
        public EventType event_type { get; set; }
        public EventStatus event_status { get; set; }
        public Venue venue { get; set; }
        public Weather weather { get; set; }
        public CoinToss coin_toss { get; set; }
        public string tickets_url { get; set; }
        public Team1 team_1 { get; set; }
        public Team2 team_2 { get; set; }
    }
}
