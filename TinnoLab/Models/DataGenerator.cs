using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinnoLab.DataContext;

namespace TinnoLab.Models
{
    public class DataGenerator
    {
        /*
         * This class is just here for initializing a list of topics with some default topic
         */

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TopicDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<TopicDBContext>>()))
            {
                // Look for any topics already in database.
                if (context.Topics.Any())
                {
                    return;   // Database has been seeded
                }

                context.Topics.AddRange(
                    new Topic
                    {
                        Id = Guid.NewGuid(),
                        Title = "IOS 13 update rolled out today!",
                        Content = "Apple releases new IOS 13 with amazing new features!",
                        CreatedBy = "AppleEverything",
                        UpVote = 73,
                        DownVote = 8,
                        CreatedDate = DateTime.Now
                    },
                    new Topic
                    {
                        Id = Guid.NewGuid(),
                        Title = "New life forms discovered on mars",
                        Content = "Scientist discover new bacteria from samples extracted from marc prove there was life in mars.",
                        CreatedBy = "MarsRoverExperts",
                        UpVote = 74,
                        DownVote = 0,
                        CreatedDate = DateTime.Now
                    },
                    new Topic
                    {
                        Id = Guid.NewGuid(),
                        Title = "UFO sighted in Russia.",
                        Content = "Amature photographer took a picture of the moon and discover a movie light flown across the sky.",
                        CreatedBy = "TruthIsOutThere",
                        UpVote = 385,
                        DownVote = 68,
                        CreatedDate = DateTime.Now
                    },
                    new Topic
                    {
                        Id = Guid.NewGuid(),
                        Title = "Malaysian badminton player bring home another throphy.",
                        Content = "Malaysian badminton player Datuk LCY brings home another throphy from this year competition.",
                        CreatedBy = "MalaysiaBoleh",
                        UpVote = 1074,
                        DownVote = 0,
                        CreatedDate = DateTime.Now
                    },
                    new Topic
                    {
                        Id = Guid.NewGuid(),
                        Title = "Exotic bugs found in travellers hand carry at MY Airport",
                        Content = "Dozen of rare bugs were found in a businessman hand carry bags.",
                        CreatedBy = "NewsToday",
                        UpVote = 137,
                        DownVote = 2,
                        CreatedDate = DateTime.Now
                    }); ;

                context.SaveChanges();
            }
        }
    }
}
