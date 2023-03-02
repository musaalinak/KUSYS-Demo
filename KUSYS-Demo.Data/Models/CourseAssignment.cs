using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Data.Models
{
    public class CourseAssignment
    {
        [Key]
        public int CourseAssignmentId { get; set; }

        public string CourseId { get; set; } = string.Empty;
        public int StudentId { get; set; }

        virtual public Course Course { get; set; }= new Course();
        virtual public Student Student { get; set; }=new Student();
    }
}
