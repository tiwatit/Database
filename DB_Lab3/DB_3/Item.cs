using System;
using System.Collections.Generic;

#nullable disable

namespace DB_3
{
    public partial class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Atk { get; set; }

        public virtual CharactersItem CharactersItem { get; set; }
    }
}
