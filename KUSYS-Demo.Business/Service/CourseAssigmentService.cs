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
    public class CourseAssigmentService : Service<CourseAssignment>
    {
        CourseAssigmentRepository repository;
        CourseService courseService;
        public CourseAssigmentService(Context context) : base(new CourseAssigmentRepository(context))
        {
            repository = new CourseAssigmentRepository(context);
            courseService = new CourseService(context);
        }

        public List<CourseAssignment> GetCourseAssigmentsByStudent(int studentId)
        {
            List<CourseAssignment> courses = new List<CourseAssignment>();
            courses=repository.GetCourseAssigmentsByStudent(studentId).ToList();
            return courses;
        }

        public List<Course> GetUnassignedCoursesByStudent(int studentId)
        {
            List<Course> unAssignedCourses = new List<Course>();
            List<Course> courses = GetCourseAssigmentsByStudent(studentId).Select(x=>x.Course).ToList();
            foreach (Course course in courseService.GetList())
            {
                if (!courses.Contains(course))
                { unAssignedCourses.Add(course); }
            }
            return unAssignedCourses;
        }
    }
}
