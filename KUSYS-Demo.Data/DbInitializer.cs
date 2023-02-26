using KUSYS_Demo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Course>().HasData(
                   new Course() { CourseId = "CSI101", CourseName = "Introduction to Computer Science" },
                   new Course() { CourseId= "CSI102" ,CourseName= "Algorithms" },
                   new Course() { CourseId= "MAT101" ,CourseName= "Calculus" },
                   new Course() { CourseId= "PHY101" ,CourseName= "Physics" }

            );
        }
    }
}
