using SUKTIE.Data;
using SUKTIE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SUKTIE.Controllers
{
    public class HomeController : Controller
    {
        PostsRepository _repo = new PostsRepository();
        HashtagsRepository _hepo = new HashtagsRepository();
        StaticPageRepository _stepo = new StaticPageRepository();
        public ActionResult Index(IndexViewModel model)
        {
            model.StaticPages = _stepo.StaticPageSelectAll().ToList();
            model.Post = _repo.PostsSelectMostRecent().SingleOrDefault();
            model.Recent15 = _repo.PostsSelect15().ToList();
            model.Hashtags = _hepo.HashtagSelectByPostId(model.Post.PostId).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(IndexViewModel model, int id)
        {
            model.Recent15 = _repo.PostsSelect15().ToList();
            model.Post = _repo.PostSelectById(id).SingleOrDefault();
            model.Hashtags = _hepo.HashtagSelectByPostId(id).ToList();
            model.StaticPages = _stepo.StaticPageSelectAll().ToList();
            return View(model);
        }

        public ActionResult About(BaseViewModel model)
        {
            
            model.Recent15 = _repo.PostsSelect15().ToList();
            model.StaticPages = _stepo.StaticPageSelectAll().ToList();
            ViewBag.Message = "Your application description page.";

            return View(model);
        }

        public ActionResult Contact(BaseViewModel model)
        {
            
            model.Recent15 = _repo.PostsSelect15().ToList();
            model.StaticPages = _stepo.StaticPageSelectAll().ToList();
            ViewBag.Message = "Your contact page.";

            return View(model);
        }

        public ActionResult Search(int id)
        {
            var model = new SearchViewModel();
            model.Recent15 = _repo.PostsSelect15().ToList();
            model.StaticPages = _stepo.StaticPageSelectAll().ToList();
            model.Posts = _repo.PostsSelectByHashtagId(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(string hashtag)
        {
            var model = new SearchViewModel();
            model.Recent15 = _repo.PostsSelect15().ToList();
            model.StaticPages = _stepo.StaticPageSelectAll().ToList();
            model.Posts = _repo.PostsSelectByHashtagName(hashtag);
            return View(model);
        }

        public ActionResult Archives()
        {
            var model = new SearchViewModel();
            model.StaticPages = _stepo.StaticPageSelectAll().ToList();
            model.Recent15 = _repo.PostsSelect15().ToList();
            model.Posts = _repo.PostsSelectAll();
            return View(model);
        }

    }
}