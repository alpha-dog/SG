using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            StudentRepository.Add(studentVM.Student);

            return RedirectToAction("List");
        }
        public ActionResult EditStudent(int id)
        {
            var student = StudentRepository.Get(id);
            return View(student);
        }
        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            StudentRepository.Edit(student);
            return RedirectToAction("Students");
        }
        public ActionResult Delete(int id)
        {
            var student = StudentRepository.Get(id);
            return View(student);
        }
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("Students");
        }
        
        //public ActionResult DeleteCourse(int id)
        //{
        //    var course = CourseRepository.Get(id);
        //    return View(course);
        //}
        //[HttpPost]
        //public ActionResult DeleteCourse(Course course)
        //{
        //    CourseRepository.Delete(course.CourseId);
        //    return RedirectToAction("Courses");
        //}
    }
}
