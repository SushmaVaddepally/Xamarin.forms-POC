namespace GamesZone.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Example
    {
        public IList<Player> data { get; set; }
        public IList<object> errors { get; set; }
        public Meta meta { get; set; }
    }
}
