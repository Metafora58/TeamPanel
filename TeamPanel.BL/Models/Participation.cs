using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TeamPanel.BL.Models
{
    public partial class Participation
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "player-id")]
        public long PlayerId { get; set; }
        [DataMember(Name = "activity-id")]
        public int ActivityId { get; set; }
    }
}
