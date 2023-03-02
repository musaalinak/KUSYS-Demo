using KUSYS_Demo.Data;
using KUSYS_Demo.Data.Models;
using KUSYS_Demo.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Business.Service
{
    public class CourseService:Service<Course>
    {
        CourseRepository repository;
        public CourseService(Context context):base(new CourseRepository(context))
        { 
            repository= new CourseRepository(context);
        }

    }
}
