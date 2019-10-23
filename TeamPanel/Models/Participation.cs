using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TeamPanel.Models
{
    public partial class Participation
    {
        public int Id { get; set; }

        public long PlayerId { get; set; }

        public int ActivityId { get; set; }
    }
}
