using course_net_core_software.Models;
using course_net_core_software.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.Threading.Tasks;

namespace course_net_core_software.Controllers
{
    public class HomeController : Controller
    {
        private IStockFriend _stockFriend;
        private IWebHostEnvironment hosting;

        public HomeController(IStockFriend stockFriend, IWebHostEnvironment hostingEnvironment)
        {
            _stockFriend = stockFriend;
            hosting = hostingEnvironment;
        }

        public ViewResult Index()
        {
            List<Friend> model = _stockFriend.getAllFriend();

            return View(model);
        }

        public ViewResult MyView() {
            return View("~/MyViews/Index.cshtml");
        }

        public ViewResult Details(int? id)
        {
            DetailsView detail = new DetailsView();
            detail.Title = "List Friends";
            detail.SubTitle = DateTime.Now.ToString("dd/MM/yyyy");
            detail.Friend = _stockFriend.giveMeDataFriend(id ?? 2);

            if (detail.Friend == null) {
                Response.StatusCode = 404;
                return View("FriendNotFound", id);
            }

            return View(detail);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateFriendModel a)
        {
            if (ModelState.IsValid)
            {
                string guidImages = null;
                if (a.Photo != null)
                {
                    string imagesFiles = Path.Combine(hosting.WebRootPath, "img");
                    guidImages = Guid.NewGuid().ToString() + a.Photo.FileName;
                    string route = Path.Combine(imagesFiles, guidImages);
                    a.Photo.CopyTo(new FileStream(route, FileMode.Create));
                }


                Friend newFriend = new Friend();
                newFriend.Name = a.Name;
                newFriend.Email = a.Email;
                newFriend.City = a.City;
                newFriend.RoutePhoto = guidImages;

                _stockFriend.newFriend(newFriend);
                return RedirectToAction("index");
                //return RedirectToAction("details", new { id = newFriend.Id });
            }

            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id) {

            Friend friend = _stockFriend.giveMeDataFriend(id);
            EditFriendModel editFriend = new EditFriendModel {
                Id = friend.Id,
                Name = friend.Name,
                Email = friend.Email,
                City = friend.City,
                PhotoExistingRoute = friend.RoutePhoto
            };

            return View(editFriend);
        }

        [HttpPost]
        public IActionResult edit(EditFriendModel model)
        {
            if (ModelState.IsValid)
            {
                //we get the data from our friend
                Friend friend = _stockFriend.giveMeDataFriend(model.Id);

                //update the model object data
                friend.Name = model.Name;
                friend.Email = model.Email;
                friend.City = model.City;

                if (model.Photo != null)
                {
                    //if a user uploads a photo they must delete the previous photo
                    if (model.PhotoExistingRoute != null)
                    {
                        string route = Path.Combine(hosting.WebRootPath, "img", model.PhotoExistingRoute);
                        System.IO.File.Delete(route);
                    }

                    // save the photo in wwwroot/img/
                    friend.RoutePhoto = uploadImage(model);

                }
                Friend customFriend = _stockFriend.update(friend);

                return RedirectToAction("index");


            }

            return View(model);
        }
        private string uploadImage(EditFriendModel model){
            string filename = null;
            if (model.Photo != null)
            {
                string folderUploaded = Path.Combine(hosting.WebRootPath, "img");
                filename = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string route = Path.Combine(folderUploaded, filename);
                using (var fileStream = new FileStream(route, FileMode.Create)) {
                    model.Photo.CopyTo(fileStream);
                }
                 //fileStream.close();
            }
            return filename;
        }
    }
}