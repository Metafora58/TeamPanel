using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TeamPanel.BL.Models
{
    public partial class Gender
    {
        [DataMember(Name = "id")]
        public byte Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
