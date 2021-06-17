using Erratas.Domain.Entities;
using Erratas.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Erratas.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        public HomeController(DataManager data)
        {
            this.dataManager = data;
        }

        public IActionResult Index()
        {
            return View(dataManager.Categories.GetCategories());
        }

        public IActionResult Show(string category)
        {
            IQueryable<Post> posts = dataManager.Posts
                .GetPosts()
                .Where(p => p.Category == category);

            ViewBag.CurrentCategory = category;
            return View(posts);
        }

        public IActionResult Post(Guid postId)
        {
            Post post = dataManager.Posts.GetPostById(postId);
            return View("CertainPost", post);
        }
    }
}
