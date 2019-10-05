using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinnoLab.Models
{
    public class Topic
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }
        public int UpVote { get; set; }
        public int DownVote { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
