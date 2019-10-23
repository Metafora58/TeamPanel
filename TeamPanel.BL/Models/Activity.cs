using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TeamPanel.BL.Models
{
    public class Activity
    {
        [DataMember(Name="id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "image-id")]
        public long? ImageId { get; set; }
        [DataMember(Name = "creation-time")]
        public DateTime CreationTime { get; set; }
        [DataMember(Name = "last-modification-time")]
        public DateTime? LastModificationTime { get; set; }
        [DataMember(Name = "created-by")]
        public int CreatedBy { get; set; }
        [DataMember(Name = "modified-by")]
        public int? ModifiedBy { get; set; }
    }
}
