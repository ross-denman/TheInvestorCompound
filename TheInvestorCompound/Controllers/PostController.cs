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
    // [Authorize]  // We'll play with this, but ultimately want this to be public
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
            if (!ModelState.IsValid) return View(model);

            var service = CreatePostService();

            if (service.CreatePost(model))
            {
                TempData["SaveResult"] = "Your post was created.";
                return RedirectToAction("index");
            };

            ModelState.AddModelError("", "Post could not be created.");
            return View(model);
        }

        public ActionResult Details (int id)
        {
            var svc = CreatePostService();
            var model = svc.GetPostById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePostService();
            var detail = service.GetPostById(id);
            var model = new PostEdit
            {
                PostId = detail.PostId,
                PostName = detail.PostName,
                PostCoverImage = detail.PostCoverImage,
                PostContent = detail.PostContent
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PostEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.PostId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePostService();

            if (service.UpdatePost(model))
            {
                TempData["Save Result"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePostService();
            var model = svc.GetPostById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePostService();
            service.DeletePost(id);
            TempData["SaveResult"] = "Your note was deleted";
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