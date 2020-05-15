namespace GamesZone.Models
{
    using System.Collections.Generic;

    public class GamesInformation
    {
        public IList<Game> data { get; set; }
        public IList<object> errors { get; set; }
        public Meta meta { get; set; }
    }
}
