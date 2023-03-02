using KUSYS_Demo.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Context>>()))
            {
                List<Course> courses = null;

                // Look for any movies.
                if (!context.Courses.Any())
                {
                    courses = new List<Course>
                    {
                        new Course() { CourseId = "CSI101", CourseName = "Introduction to Computer Science" },
                        new Course() { CourseId = "CSI102", CourseName = "Algorithms" },
                        new Course() { CourseId = "MAT101", CourseName = "Calculus" },
                        new Course() { CourseId = "PHY101", CourseName = "Physics" }
                    };

                    context.Courses.AddRange(courses);
                }



                List<Student> students = null;
                if (!context.Students.Any())
                {
                    students = new List<Student>
                    {
                        new Student() { FirstName = "Musa", LastName = "Alınak", BirthDate = DateTime.ParseExact("05.04.1995", "dd.mm.yyyy", CultureInfo.InvariantCulture) }
                    };
                    context.Students.AddRange(students);
                }



                if (!context.CourseAssignments.Any() && students != null&& courses!=null)
                {
                    context.CourseAssignments.AddRange(
                        new CourseAssignment() { Course = courses[0], Student = students[0] });
                }


                context.SaveChanges();
            }
        }
    }
}