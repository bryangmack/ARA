using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARA.Domain.Entities;

namespace ARA.Domain.Abstract
{
    public interface ICourseRepository
    {
        IEnumerable<Course> Courses { get; }
        void SaveCourse(Course course);
    }
}
