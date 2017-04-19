using Microsoft.AspNet.Identity;
using SUKTIE.Data;
using SUKTIE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SUKTIE.Controllers
{
    public class StaticPageController : Controller
    {
        PostsRepository _repo = new PostsRepository();
        HashtagsRepository _hepo = new HashtagsRepository();
        StaticPageRepository _stepo = new StaticPageRepository();

        // GET: StaticPage
        public ActionResult Create()
        {

            var model = new StaticPageViewModel();
            model.StaticPages = _stepo.StaticPageSelectAll().ToList();
            model.Recent15 = _repo.PostsSelect15().ToList();
            return View(model);
        }

        // POST: Post/Create
        //[Authorize]
        [AllowAnonymous]
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(StaticPageViewModel model)
        {
            //var repo = new PostsRepository();
            model.StaticPage.UserId = User.Identity.GetUserId();
            model.StaticPage = _stepo.Add(model.StaticPage);
            return RedirectToAction("Create");

        }

        public ActionResult View(int id)
        {


            var model = new StaticPageViewModel();
            model.StaticPages = _stepo.StaticPageSelectAll().ToList();
            model.Recent15 = _repo.PostsSelect15().ToList();
            model.StaticPage = _stepo.StaticPageSelectById(id).SingleOrDefault();
            return View(model);
        }

        public ActionResult Edit(int id)
        {

            var model = new StaticPageViewModel();
            model.StaticPages = _stepo.StaticPageSelectAll().ToList();
            model.Recent15 = _repo.PostsSelect15().ToList();
            model.StaticPage = _stepo.StaticPageSelectById(id).SingleOrDefault();
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(StaticPageViewModel model)
        {
            //var repo = new PostsRepository();
            model.StaticPage.UserId = User.Identity.GetUserId();
            model.StaticPage = _stepo.Edit(model.StaticPage);
            return RedirectToAction("View", new { id = model.StaticPage.StaticPageId});

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            

            _stepo.Delete(id);
            

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}