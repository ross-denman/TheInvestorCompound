using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheInvestorCompound.Models;
using TheInvestorCompound.Services;

namespace TheInvestorCompound.Controllers
{
    [Authorize]  // We'll play with this, but ultimately want this to be public
    public class PostController : Controller
    {
        // GET : Post
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userId);
            var model = service.GetPosts();

            return View(model);
        }

        // GET : Create
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreatePostService();

            service.CreatePost(model);

            return RedirectToAction("Index");
        }

        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userId);
            return service;
        }
    }
}