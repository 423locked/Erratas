using Erratas.Domain.Entities;
using Erratas.Domain.Repositories;
using Erratas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Show(string category, int pageIndex = 1)
        {
            IQueryable<Post> posts = dataManager.Posts
                .GetPosts()
                .Where(p => p.Category == category);

            ViewBag.CurrentCategory = category;
            ViewBag.CollectionLength = await posts.CountAsync();

            return View(await PaginatedList<Post>.CreateAsync(posts, pageIndex, 3));
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

        public async Task<IActionResult> Posts(int pageIndex = 1)
        {
            IQueryable<Post> posts = dataManager.Posts.GetPosts();
            ViewBag.CollectionLength = await posts.CountAsync();

            return View(await PaginatedList<Post>.CreateAsync(posts, pageIndex, 9));
        }

        public async Task<IActionResult> Search(string query, int pageIndex = 1)
        {
            ViewBag.Query = query;

            var task = dataManager.Posts.SearchPostsAsync(query);
            List<Post> posts = await task;
            if (task.Wait(5000))
            {
                // task executed correctly in under 5 secs
                ViewBag.CollectionLength = posts.Count;
                return View(PaginatedList<Post>.CreateAsync(posts, pageIndex, 3));
            }
            else 
                return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult SubmitContactForm(ContactCustomer customer)
        {
            ViewBag.Name = customer.Name;
            dataManager.ContactCustomers.SaveContactCustomer(customer);
            return View();
        }

        [Authorize]
        public IActionResult LikePost(Guid postId, string returnUrl)
        {
            if (!dataManager.UserLikedPosts.IsPostLiked(postId))
            {
                dataManager.UserLikedPosts.AddPost(postId);
                dataManager.Posts.LikePost(postId);
            }
            return Redirect(returnUrl ?? "/");
        }
    }
}
