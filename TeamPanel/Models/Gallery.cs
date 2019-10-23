using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TeamPanel.Models
{
    public class Gallery
    {
        public long Id { get; set; }

        public string ImageName { get; set; }

        public string ImagePath { get; set; }
    }
}
