using Erratas.Domain.Entities;
using Erratas.Domain.Repositories;
using Erratas.Models;
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
    public class CategoriesController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment;
        public CategoriesController(DataManager data, IWebHostEnvironment env)
        {
            this.dataManager = data;
            this.hostEnvironment = env;
        }

        public async Task<IActionResult> Index(int pageIndex = 1)
        {
            IQueryable<Category> categories = dataManager.Categories.GetCategories();
            return View(await PaginatedList<Category>.CreateAsync(categories, pageIndex, 3));
        }

        public IActionResult Edit(Guid id)
        {
            Category category = dataManager.Categories.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category model, IFormFile file)
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


                dataManager.Categories.SaveCategory(model);
                return RedirectToAction("Index", "Categories");
            }
            return View(model);
        }
        
        public IActionResult Delete(Guid id)
        {
            dataManager.Categories.DeleteCategory(id);
            return RedirectToAction("Index", "Categories");
        }
    }
}
