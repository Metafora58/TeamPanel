using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TeamPanel.Models
{
    public partial class Team
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "identifier")]
        public string Identifier { get; set; }
        [DataMember(Name = "activity-id")]
        public int? ActivityId { get; set; }
        [DataMember(Name = "captain-id")]
        public long CaptainId { get; set; }
        [DataMember(Name = "image-id")]
        public long? ImageId { get; set; }
    }
}
