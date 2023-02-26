using KUSYS_Demo.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace KUSYS_Demo.Web.Models
{
    public class StudentListViewModel
    {

        public StudentListViewModel(Student student)
        {
            Id = student.StudentId;
            FirstName = student.FirstName;
            LastName = student.LastName;
            BirthDateValue = student.BirthDate;
        }

        public int Id { get; set; }

        private string FirstName;

        private string LastName;

        [Display(Name="Öğrenci Adı")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        [Display(Name = "Doğum Tarihi")]
        public string BirthDate { get; set; }



        private DateTime BirthDateValue
        {
            set
            {
                BirthDate = value.ToString("dd.MM.yyyy");
            }
        }


    }
}
