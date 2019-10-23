using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TeamPanel.Models
{
    public partial class Player
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public byte? GenderId { get; set; }

        public long? ImageId { get; set; }
    }
}
