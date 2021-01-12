using System;
using System.Collections.Generic;

#nullable disable

namespace DB_3
{
    public partial class CharactersItem
    {
        public int LinkId { get; set; }
        public int CharId { get; set; }
        public int ItemId { get; set; }

        public virtual Character Char { get; set; }
        public virtual Item Link { get; set; }
    }
}
