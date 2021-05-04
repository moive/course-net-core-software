using course_net_core_software.Models;
using course_net_core_software.ViewModels;
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

        public ViewResult Index()
        {
            List<Friend> model = _stockFriend.getAllFriend();

            return View(model);
        }

        public ViewResult MyView() {
            return View("~/MyViews/Index.cshtml");
        }

        public ViewResult Details()
        {
            DetailsView detail = new DetailsView();
            detail.Title = "List Friends";
            detail.SubTitle = DateTime.Now.ToString("dd/MM/yyyy");
            detail.Friend = _stockFriend.giveMeDataFriend(3);

            return View(detail);
        }
    }
}