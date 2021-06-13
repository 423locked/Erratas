using Erratas.Domain.Entities;
using Erratas.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erratas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostsController : Controller
    {
        private readonly DataManager dataManager;
        public PostsController(DataManager data)
        {
            this.dataManager = data;
        }

        public IActionResult Index()
        {
            return View(dataManager.Posts.GetPosts());
        }

        public IActionResult Edit(Guid id)
        {
            ViewBag.Categories = dataManager.Categories.GetCategories().ToList();
            Post post = dataManager.Posts.GetPostById(id);
            return View(post);
        }

        [HttpPost]
        public IActionResult Edit(Post model)
        {
            if (ModelState.IsValid)
            {
                dataManager.Posts.SavePost(model);
                return RedirectToAction("Index", "Posts");
            }
            return View(model);
        }

        public IActionResult Delete(Guid id)
        {
            dataManager.Posts.DeletePost(id);
            return RedirectToAction("Index", "Posts");
        }
    }
}
