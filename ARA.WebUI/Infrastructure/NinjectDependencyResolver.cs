using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using ARA.Domain.Abstract;
using ARA.Domain.Concrete;
using ARA.Domain.Entities;


namespace ARA.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            Mock<ICourseRepository> mock = new Mock<ICourseRepository>();
            mock.Setup(m => m.Courses).Returns(new List<Course>
            {
                new Course {CourseID = 1, Name = "Course 1"},
                new Course {CourseID = 2, Name = "Course 2"},
                new Course {CourseID = 3, Name = "Course 3"}
            });

            //kernel.Bind<ICourseRepository>().ToConstant(mock.Object);
            kernel.Bind<ICourseRepository>().To<EFCourseRepository>();
        }
    }
}