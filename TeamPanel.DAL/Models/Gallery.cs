using System;
using System.Collections.Generic;

namespace TeamPanel.DAL.Models
{
    public partial class Gallery
    {
        public Gallery()
        {
            Activity = new HashSet<Activity>();
            Player = new HashSet<Player>();
            Team = new HashSet<Team>();
        }

        public long Id { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }

        public virtual ICollection<Activity> Activity { get; set; }
        public virtual ICollection<Player> Player { get; set; }
        public virtual ICollection<Team> Team { get; set; }
    }
}
