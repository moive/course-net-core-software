using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course_net_core_software.Controllers
{
    public class ErrorController1 : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case  404:
                    ViewBag.ErrorMessage = "The requested resouce cannot be found";
                    break;
            }
            return View("Error");
        }
    }
}
