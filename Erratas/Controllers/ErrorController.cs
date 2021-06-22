using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erratas.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            ViewBag.ErrorCode = statusCode;

            if (statusCode == 404) 
                ViewBag.ErrorMessage = "Sorry, the entity you were looking for does not exist. Please recheck the link.";
            else 
                ViewBag.ErrorMessage = "Sorry, an error occured, please recheck the initial link.";

            return View("Error");
        }
    }
}
