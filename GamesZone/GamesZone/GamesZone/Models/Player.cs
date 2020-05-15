namespace GamesZone.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Player
    {
        public int cfl_central_id { get; set; }
        public int stats_inc_id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string birth_date { get; set; }
        public string birth_place { get; set; }
        public string height { get; set; }
        public int weight { get; set; }
        public int? rookie_year { get; set; }
        public bool foreign_player { get; set; }
        public string image_url { get; set; }
        public School school { get; set; }
        public Position position { get; set; }

        public string FullName { get; set; }
    }
}
