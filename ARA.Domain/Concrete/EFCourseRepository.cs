using ARA.Domain.Abstract;
using ARA.Domain.Entities;
using System.Collections.Generic;

namespace ARA.Domain.Concrete
{
    public class EFCourseRepository :ICourseRepository
    {
        private AutoRegistrationEntities context = new AutoRegistrationEntities();
        public IEnumerable<Course> Courses
        {
            get { return context.Courses;  }
        }

        public void SaveCourse(Course course)
        {
            if (course.CourseID == 0)
            {
                context.Courses.Add(course);
            }
            else
            {
                Course dbEntry = context.Courses.Find(course.CourseID);
                if (dbEntry != null)
                {
                    dbEntry.Name = course.Name;
                }
            }
            context.SaveChanges();
        }
    }
}
