using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TeamPanel.BL.Models
{
    public partial class Player
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }
        [DataMember(Name = "first-name")]
        public string FirstName { get; set; }
        [DataMember(Name = "last-name")]
        public string LastName { get; set; }
        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }
        [DataMember(Name = "username")]
        public string Username { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "phone-number")]
        public string PhoneNumber { get; set; }
        [DataMember(Name = "gender-id")]
        public byte? GenderId { get; set; }
        [DataMember(Name = "image-id")]
        public long? ImageId { get; set; }
        [DataMember(Name = "creation-time")]
        public DateTime CreationTime { get; set; }
        [DataMember(Name = "last-modification-time")]
        public DateTime? LastModificationTime { get; set; }
    }
}
