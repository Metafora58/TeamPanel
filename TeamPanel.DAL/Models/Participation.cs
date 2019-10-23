using System;
using System.Collections.Generic;

namespace TeamPanel.DAL.Models
{
    public partial class Participation
    {
        public int Id { get; set; }
        public long PlayerId { get; set; }
        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual Player Player { get; set; }
    }
}
