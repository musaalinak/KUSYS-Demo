using KUSYS_Demo.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace KUSYS_Demo.Web.Models
{
    public class CourseAssigmentViewModel
    {


        public CourseAssigmentViewModel(Course course)
        {
            Id = course.CourseId;
            Name = course.CourseName;
        }
        [Display(Name = "Course ID")]
        public string Id { get; set; }
        [Display(Name = "Course Name")]
        public string Name { get; set; }
    }

    public class CourseAssigmentListViewModel : CourseAssigmentViewModel
    {

        public CourseAssigmentListViewModel(CourseAssignment courseAssignment) : base(courseAssignment.Course)
        {
        }


    }
    public class CourseAssigmentAssignViewModel
    {
        public CourseAssigmentAssignViewModel()
        {
        }

        public CourseAssigmentAssignViewModel(List<Course> _courses, int _studentId)
        {
            Courses = new List<SelectListItem>();
            foreach (var item in _courses)
            {
                Courses.Add(new SelectListItem { Text = item.CourseId + " - " + item.CourseName, Value = item.CourseId });
            }
            StudentId = _studentId;
        }
        [Display(Name = "Course ID")]
        public string Id { get; set; }
        public int StudentId { get; set; }
        public List<SelectListItem> Courses { get; set; }

        public CourseAssignment GetObjectFromCollection(IFormCollection collection)
        {

            var assigment = new CourseAssignment
            {
                StudentId = int.Parse(collection["StudentId"]),
                CourseId = collection["Id"],
                Course = null,
                Student = null
            };
            return assigment;
        }
    }
}
