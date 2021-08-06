﻿using Erratas.Domain.Entities;
using Erratas.Domain.Repositories;
using Erratas.Models;
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

        public async Task<IActionResult> Index(int pageIndex = 1)
        {
            IQueryable<Category> categories = dataManager.Categories.GetCategories();
            return View(await PaginatedList<Category>.CreateAsync(categories, pageIndex, 3));
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


        [HttpPost]
        public async Task<IActionResult> Search(string query)
        {
            ViewBag.Query = query;

            var task = dataManager.Posts.SearchPostsAsync(query);
            List<Post> posts = await task;
            if (task.Wait(5000))
            {
                // task executed correctly in under 5 secs
                return View(posts);
            }
            else 
                return View();
        }
    }
}
