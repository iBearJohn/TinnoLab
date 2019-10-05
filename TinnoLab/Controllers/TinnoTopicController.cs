using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TinnoLab.DataContext;
using TinnoLab.Models;

/* 
 * This is the Web Services for Mobile Platform
 * All it does is returning a json topic object or list
 */

namespace TinnoLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinnoTopicController : ControllerBase
    {
        private TopicDBContext _context;

        public TinnoTopicController(TopicDBContext context)
        {
            //initialize the context with the auto generated topics
            _context = context;
        }

        [HttpGet]
        [Route("GetTopics")]
        public IActionResult GetTopics()
        {
            // get top 20 result from the list which is already sorted by upvote in descending order
            var topics = _context.Topics.ToList().OrderByDescending(t => t.UpVote).Take(20);

            // return a okay status with the list
            return Ok(topics);
        }

        [HttpPost]
        [Route("AddTopic")]
        public IActionResult AddTopic(Topic newTopic)
        {
            // add the extra information to the new topic
            newTopic.Id = Guid.NewGuid();
            newTopic.UpVote = 0;
            newTopic.DownVote = 0;
            newTopic.CreatedBy = "DemoUser01";
            newTopic.CreatedDate = DateTime.Now;

            // add the new topic to the list in memory
            _context.Topics.Add(newTopic);

            // save the edited list to memory
            _context.SaveChanges();

            // get top 20 result from the list which is already sorted by upvote in descending order
            var topics = _context.Topics.ToList().OrderByDescending(t => t.UpVote).Take(20);

            // return a okay status with the list
            return Ok(topics);
        }

        [HttpPost]
        [Route("UpVote")]
        public IActionResult UpVote(Topic topic)
        {
            // get the topic in list that have the same topic id and increase the upvote by 1
            _context.Topics.Where(t => t.Id == topic.Id).First().UpVote += 1;

            // save the edited list to memory
            _context.SaveChanges();

            // get top 20 result from the list which is already sorted by upvote in descending order
            var topics = _context.Topics.ToList().OrderByDescending(t => t.UpVote).Take(20);

            // return a okay status with the list
            return Ok(topics);
        }

        [HttpPost]
        [Route("DownVote")]
        public IActionResult DownVote(Topic topic)
        {
            // get the topic in list that have the same topic id and increase the downvote by 1
            _context.Topics.Where(t => t.Id == topic.Id).First().DownVote += 1;

            // save the edited list to memory
            _context.SaveChanges();

            // get top 20 result from the list which is already sorted by upvote in descending order
            var topics = _context.Topics.ToList().OrderByDescending(t => t.UpVote).Take(20);

            // return a okay status with the list
            return Ok(topics);
        }

    }
}