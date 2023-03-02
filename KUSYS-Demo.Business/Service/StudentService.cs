using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KUSYS_Demo.Data;
using KUSYS_Demo.Data.Models;
using KUSYS_Demo.Data.Repositories;

namespace KUSYS_Demo.Business.Service
{
    public class StudentService:Service<Student>
    {
        StudentRepository repository;
        public StudentService(Context context):base(new StudentRepository(context))
        {
            repository = new StudentRepository(context);
        }

    }
}
