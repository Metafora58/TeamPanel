using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TeamPanel.Models
{
    public class Activity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long? ImageId { get; set; }
    }
}
