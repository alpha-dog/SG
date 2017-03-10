using Exercises.Models.Data;
using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//I HAVE MADE CHANGES TO THE PROJECT
namespace Exercises.Controllers
{
    public class AdminController : Controller
    {

        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new Major());
        }

        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            MajorRepository.Add(major.MajorName);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult EditMajor(Major major)
        {
            MajorRepository.Edit(major);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }
        public ActionResult States()
        {
            var model = StateRepository.GetAll();
            return View(model.ToList());
        }
        [HttpGet]
        public ActionResult AddState()
        {
            return View(new State());
        }
        [HttpPost]
        public ActionResult AddState(State state)
        {
            StateRepository.Add(state);
            return RedirectToAction("States");
        }

        public ActionResult EditState(string stateAbbreviation)
        {
            var state = StateRepository.Get(stateAbbreviation);
            return View(state);
        }
        [HttpPost]
        public ActionResult EditState(State state)
        {
            StateRepository.Edit(state);
            return RedirectToAction("States");
        }
        public ActionResult DeleteState(string stateAbbreviation)
        {
            var state = StateRepository.Get(stateAbbreviation);
            return View(state);
        }
        [HttpPost]
        public ActionResult DeleteState(State state)
        {
            StateRepository.Delete(state.StateAbbreviation);
            return RedirectToAction("States");
        }
        //LIST, ADD, EDIT, DELETE COURSES
        public ActionResult Courses()
        {
            var model = CourseRepository.GetAll();
            return View(model.ToList());
        }

        public ActionResult AddCourse()
        {
            return View(new Course());
        }
        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            CourseRepository.Add(course.CourseName);
            return RedirectToAction("Courses");
        }
        public ActionResult EditCourse (int id)
        {
            var course = CourseRepository.Get(id);
            return View(course);
        }
        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            CourseRepository.Edit(course);
            return RedirectToAction("Courses");
        }
        public ActionResult DeleteCourse(int id)
        {
            var course = CourseRepository.Get(id);
            return View(course);
        }
        [HttpPost]
        public ActionResult DeleteCourse(Course course)
        {
            CourseRepository.Delete(course.CourseId);
            return RedirectToAction("Courses");
        }
        
        //[HttpPost]
        //public ActionResult DeleteState(State state)
        //{
        //    StateRepository.Delete(state.StateAbbreviation);
        //    return RedirectToAction("States");
        //}   
    }

}