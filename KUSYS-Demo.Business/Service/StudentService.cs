using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KUSYS_Demo.Data.Models;
using KUSYS_Demo.Data.Repositories;

namespace KUSYS_Demo.Business.Service
{
    public class StudentService
    {
        StudentRepository repository;
        public StudentService()
        {
            repository = new StudentRepository();
        }
        public List<Student> GetStudentsList()
        {
            return repository.GetAll().ToList();
        }
    }
}
