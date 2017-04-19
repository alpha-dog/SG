using SUKTIE.Data;
using SUKTIE.Models;
using SUKTIE.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SUKTIE.Controllers
{
    public class PostController : Controller
    {
        PostsRepository _repo = new PostsRepository();
        HashtagsRepository _hepo = new HashtagsRepository();
        StaticPageRepository _stepo = new StaticPageRepository();

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Post/Create
        public ActionResult Create()
        {

            CreatePostViewModel model = new CreatePostViewModel();
            //model.Post = _repo.PostsSelectMostRecent().SingleOrDefault();
            model.Recent15 = _repo.PostsSelect15().ToList();
            model.StaticPages = _stepo.StaticPageSelectAll().ToList();
            
         

            return View(model);
        }

        // POST: Post/Create
        //[Authorize]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Create(CreatePostViewModel model)
        {
            //var repo = new PostsRepository();

            var hashArray = model.HashtagString.Split(new[] { '#' }, StringSplitOptions.RemoveEmptyEntries).Where(h => !String.IsNullOrWhiteSpace(h)).Select(h => h.Trim());
            model.Post = _repo.Add(model.Post);
            _hepo.AssociateHashtagsWithPost(hashArray, model.Post);
            return RedirectToAction("Create");
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            var post = _repo.PostSelectById(id);
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
