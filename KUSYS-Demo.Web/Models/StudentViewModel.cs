using KUSYS_Demo.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace KUSYS_Demo.Web.Models
{

    public class StudentViewModel
    {
        public StudentViewModel(Student student)
        {
            Id = student.StudentId;
            FirstName = student.FirstName;
            LastName = student.LastName;
            BirthDateValue = student.BirthDate;
        }

        public int? Id { get; set; }
        [Display(Name = "Name")]
        public string FirstName { get; set; }
        [Display(Name = "Surname")]
        public string LastName { get; set; }
        [Display(Name = "Student")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        [Display(Name = "Birth Date")]
        public string BirthDateDisplay
        {
            get
            {
                return BirthDateValue.ToString("dd.MM.yyyy");
            }
            set {
                BirthDateValue = DateTime.ParseExact(value, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            }
        }
        [Display(Name = "Birth Date")]
        public DateTime BirthDateValue { get; set; }
    }
    public class StudentDetailsViewModel:StudentViewModel
    {
        public StudentDetailsViewModel(Student student):base(student) { }
    }

    public class StudentDeleteViewModel : StudentViewModel
    {
        public StudentDeleteViewModel(Student student):base(student){ }
    }

    public class StudentListViewModel:StudentViewModel
    {
        public StudentListViewModel(Student student):base(student) { }
    }

    public class StudentCreateViewModel:StudentViewModel
    {
        public StudentCreateViewModel(Student student) : base(student) { }

        public Student GetObjectFromCollection(IFormCollection collection)
        {

            var student = new Student
            {
                FirstName = collection["FirstName"],
                LastName = collection["LastName"],
                BirthDate = DateTime.ParseExact(collection["BirthDateValue"], "yyyy-MM-dd", CultureInfo.InvariantCulture)
            };
            FirstName = student.FirstName;
            LastName = student.LastName;
            BirthDateValue = student.BirthDate;
            return student;
        }
    }

    public class StudentEditViewModel:StudentViewModel
    {
        public StudentEditViewModel(Student student) : base(student) { }

        public Student GetObjectFromCollection(IFormCollection collection)
        {
            var student = new Student
            {
                StudentId = int.Parse(collection["Id"]),
                FirstName = collection["FirstName"],
                LastName = collection["LastName"],
                BirthDate = DateTime.ParseExact(collection["BirthDateValue"], "yyyy-MM-dd", CultureInfo.InvariantCulture)
            };
            FirstName = student.FirstName;
            LastName = student.LastName;
            BirthDateValue = student.BirthDate;
            return student;
        }
    }
}
