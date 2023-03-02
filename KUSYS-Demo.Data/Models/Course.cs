using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Data.Models
{
    public class Course
    {
        [Key]
        public string CourseId { get; set; }=string.Empty;

        public string CourseName { get; set; } = string.Empty;



        virtual public ICollection<CourseAssignment> CourseAssignments { get; set; } = new List<CourseAssignment>();
    }
}
