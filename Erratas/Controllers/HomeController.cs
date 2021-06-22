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
            if (post == null)
            {
                //throw new Exception("Post not found exception");

                Response.StatusCode = 404;
                ViewBag.ErrorCode = 404;
                ViewBag.ErrorMessage = "Sorry, there is no such post. Please revise the initial link.";
                return View("Error");
            }

            return View("CertainPost", post);
        }
    }
}
