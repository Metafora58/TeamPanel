using System;
using System.Collections.Generic;

namespace TeamPanel.DAL.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Player = new HashSet<Player>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Player> Player { get; set; }
    }
}
