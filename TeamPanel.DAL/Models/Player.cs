using System;
using System.Collections.Generic;

namespace TeamPanel.DAL.Models
{
    public partial class Player
    {
        public Player()
        {
            Participation = new HashSet<Participation>();
            Team = new HashSet<Team>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public byte? GenderId { get; set; }
        public long? ImageId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual Gallery Image { get; set; }
        public virtual ICollection<Participation> Participation { get; set; }
        public virtual ICollection<Team> Team { get; set; }
    }
}
