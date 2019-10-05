using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TinnoLab.DataContext;
using TinnoLab.Models;

namespace TinnoLab.Controllers
{
    public class HomeController : Controller
    {
        private TopicDBContext _context;

        public HomeController(TopicDBContext context)
        {
            //initialize the context with the auto generated topics
            _context = context;
        }

        public IActionResult Index()
        {
            // get top 20 result from the list which is already sorted by upvote in descending order
            var topics = _context.Topics.ToList().OrderByDescending(t => t.UpVote).Take(20);

            // return the index view with the list
            return View(topics);
        }

        [HttpGet]
        public IActionResult Add()
        {
            // return the index view
            return View();
        }

        [HttpPost]
        public IActionResult Add(Topic topic)
        {
            // add the extra information to the new topic
            topic.Id = Guid.NewGuid();
            topic.UpVote = 0;
            topic.DownVote = 0;
            topic.CreatedBy = "DemoUser01";
            topic.CreatedDate = DateTime.Now;

            // add the new topic to the list in memory
            _context.Topics.Add(topic);

            // save the edited list to memory
            _context.SaveChanges();

            // redirect to index page
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpVote(Guid id)
        {
            // get the topic in list that have the same topic id and increase the upvote by 1
            _context.Topics.Where(t => t.Id == id).First().UpVote += 1;

            // save the edited list to memory
            _context.SaveChanges();

            // redirect to index page
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DownVote(Guid id)
        {
            // get the topic in list that have the same topic id and increase the downvote by 1
            _context.Topics.Where(t => t.Id == id).First().DownVote += 1;

            // save the edited list to memory
            _context.SaveChanges();

            // redirect to index page
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
