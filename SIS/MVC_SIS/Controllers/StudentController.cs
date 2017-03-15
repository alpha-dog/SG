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
            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Add(studentVM.Student);

                return RedirectToAction("List");
            }
            else
            {
                return View("Add", studentVM);
            }
           
        }
        public ActionResult Edit(int id)
        {
            
            var studentVM = new StudentVM();
            studentVM.SetCourseItems(CourseRepository.GetAll());
            studentVM.SetMajorItems(MajorRepository.GetAll());
            studentVM.Student = StudentRepository.Get(id);
            //studentVM.Student.Address = StudentRepository.SaveAddress(id,);
            return View(studentVM);
        }
        [HttpPost]
        public ActionResult Edit(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);


                StudentRepository.Edit(studentVM.Student);
                return RedirectToAction("List");
            }
            else
            {
                return View("Edit", studentVM);
            }
            
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
            return RedirectToAction("List");
        }
        //
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
