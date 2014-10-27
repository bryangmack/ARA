using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARA.Domain.Abstract;
using ARA.Domain.Entities;

namespace ARA.WebUI.Controllers
{
    public class CoursesController : Controller
    {
        private ICourseRepository repository;

        public CoursesController(ICourseRepository courseRepository)
        {
            this.repository = courseRepository;
        }

        public ActionResult List()
        {
            return View(repository.Courses);
        }
        
        public ActionResult Edit(int id)
        {
            Course course = repository.Courses.FirstOrDefault(c => c.CourseID == id);
            return View(course);
        }

        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCourse(course);
                return RedirectToAction("List");
            }
            else
            {
                return View(course);
            }
        }
	}
}