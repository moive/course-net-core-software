using course_net_core_software.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course_net_core_software.Controllers
{
    public class HomeController : Controller
    {
        private IStockFriend _stockFriend;

        public HomeController(IStockFriend stockFriend)
        {
            _stockFriend = stockFriend;
        }

        public string Index()
        {
            return _stockFriend.giveMeDataFriend(1).Email;
        }
    }
}