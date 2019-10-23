using System;
using System.Collections.Generic;

namespace TeamPanel.DAL.Models
{
    public partial class Activity
    {
        public Activity()
        {
            Participation = new HashSet<Participation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? ImageId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Gallery Image { get; set; }
        public virtual ICollection<Participation> Participation { get; set; }
    }
}
