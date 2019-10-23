using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TeamPanel.BL.Models
{
    public class Gallery
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }
        [DataMember(Name = "image-name")]
        public string ImageName { get; set; }
        [DataMember(Name = "image-path")]
        public string ImagePath { get; set; }
    }
}
