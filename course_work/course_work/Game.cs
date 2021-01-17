using System;
using System.Collections.Generic;

#nullable disable

namespace course_work
{
    public partial class Game
    {
        public Game()
        {
            GameRatings = new HashSet<GameRating>();
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Platform { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public string AccessRating { get; set; }

        public virtual ICollection<GameRating> GameRatings { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
