using System;
using System.Collections.Generic;

#nullable disable

namespace course_work
{
    public partial class GameRating
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int RatingId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Rating Rating { get; set; }
    }
}
