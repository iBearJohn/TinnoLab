using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinnoLab.DataContext
{
    public class TopicDBContext : DbContext
    {
        public TopicDBContext(DbContextOptions<TopicDBContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Topic> Topics { get; set; }
    }
}
