using Erratas.Domain.Entities;
using Erratas.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erratas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        private readonly ILogger<HomeController> logger;

        public HomeController(DataManager data, ILogger<HomeController> log)
        {
            this.dataManager = data;
            this.logger = log;
        }

        public IActionResult Index()
        {
            logger.LogInformation("[GET] /Admin/Home/Index Invoked");
            return View();
        }

        public IActionResult CustomerIssues()
        {
            IQueryable<ContactCustomer> issues = dataManager.ContactCustomers.GetContactCustomers().OrderByDescending(x => x.DateAdded);
            return View(issues);
        }

        public IActionResult ResolveCustomerIssue(Guid id)
        {
            dataManager.ContactCustomers.ResolveContactCustomer(id);
            return RedirectToAction("CustomerIssues");
        }
    }
}
