using KUSYS_Demo.Data.Models;
using KUSYS_Demo.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Business.Service
{
    public class CourseService
    {
        CourseRepository repository;
        public CourseService() { 
            repository = new CourseRepository();
        }
        public List<Course> GetCourseList()
        {
            return repository.GetAll().ToList();
        }
    }
}
