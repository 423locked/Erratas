using Erratas.Domain.Entities;
using Erratas.Domain.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Erratas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment;
        public PostsController(DataManager data, IWebHostEnvironment env)
        {
            this.dataManager = data;
            this.hostEnvironment = env;
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
        public async Task<IActionResult> Edit(Post model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    model.TitleImagePath = file.FileName;
                    string path = "/images/" + file.FileName;
                    using (FileStream fileStream = new FileStream(hostEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
                else if (model.Id != default)
                    model.TitleImagePath = dataManager.Posts.GetPostById(model.Id).TitleImagePath;


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
