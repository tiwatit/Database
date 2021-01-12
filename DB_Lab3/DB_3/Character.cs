using System;
using System.Collections.Generic;

#nullable disable

namespace DB_3
{
    public partial class Character
    {
        public Character()
        {
            CharactersItems = new HashSet<CharactersItem>();
        }

        public int Id { get; set; }
        public string CharacterName { get; set; }
        public int Hp { get; set; }
        public int Level { get; set; }
        public int AccId { get; set; }

        public virtual Account Acc { get; set; }
        public virtual ICollection<CharactersItem> CharactersItems { get; set; }
    }
}
