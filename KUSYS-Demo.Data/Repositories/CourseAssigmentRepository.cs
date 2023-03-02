using KUSYS_Demo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Data.Repositories
{
    public class CourseAssigmentRepository : Repository<CourseAssignment>
    {
        Context context;
        public CourseAssigmentRepository(Context _context) : base(_context)
        {
            context = _context;
        }

        public CourseAssignment getAssigment(int studentId, string courseId)
        {
            return context.CourseAssignments.FirstOrDefault(x=>x.StudentId==studentId && x.CourseId.Equals(courseId));
        }

        public IEnumerable<CourseAssignment> GetCourseAssigmentsByStudent(int studentId)
        {
            return context.CourseAssignments.Include(x=>x.Course).Where(x => x.StudentId == studentId);
        }
    }
}
