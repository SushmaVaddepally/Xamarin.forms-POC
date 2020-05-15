namespace GamesZone.Models
{
    using System.Collections.Generic;

    public class Team2
    {
        public int team_id { get; set; }
        public string location { get; set; }
        public string nickname { get; set; }
        public string abbreviation { get; set; }
        public int score { get; set; }
        public int venue_id { get; set; }
        public IList<Linescore> linescores { get; set; }
        public bool is_at_home { get; set; }
        public bool is_winner { get; set; }
    }
}
