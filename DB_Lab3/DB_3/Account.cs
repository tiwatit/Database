using System;
using System.Collections.Generic;

#nullable disable

namespace DB_3
{
    public partial class Account
    {
        public Account()
        {
            Characters = new HashSet<Character>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Pword { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
    }
}
