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
    public class CategoriesController : Controller
    {
        private readonly DataManager dataManager;
        public CategoriesController(DataManager data)
        {
            this.dataManager = data;
        }

        public IActionResult Index()
        {
            return View(dataManager.Categories.GetCategories());
        }

        public IActionResult Edit(Guid id)
        {
            Category category = dataManager.Categories.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
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
