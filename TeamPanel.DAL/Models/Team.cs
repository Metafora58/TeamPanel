using System;
using System.Collections.Generic;

namespace TeamPanel.DAL.Models
{
    public partial class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
        public int? ActivityId { get; set; }
        public long CaptainId { get; set; }
        public long? ImageId { get; set; }

        public virtual Player Captain { get; set; }
        public virtual Gallery Image { get; set; }
    }
}
