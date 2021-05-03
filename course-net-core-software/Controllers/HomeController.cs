using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course_net_core_software.Controllers
{
    public class HomeController
    {
        public string Index()
        {
            return "I am in the controller Home";
        }
    }
}
