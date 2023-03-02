using KUSYS_Demo.Business.Service;
using KUSYS_Demo.Data;
using KUSYS_Demo.Data.Models;
using KUSYS_Demo.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.Web.Controllers
{
    public class StudentController : Controller
    {
        StudentService studentService;
        public StudentController(Context context)
        {
            studentService = new StudentService(context);
        }

        // GET: StudentController
        public ActionResult Index()
        {
            List<StudentListViewModel> studentList = new List<StudentListViewModel>();
            var dbStudents=studentService.GetList().OrderBy(x=>x.StudentId).ToList();
            dbStudents.ForEach(s=>studentList.Add(new StudentListViewModel(s)));
            return View(studentList);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var model=new StudentDetailsViewModel(studentService.GetById(id));
            return PartialView(model);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            StudentCreateViewModel viewModel = new StudentCreateViewModel(new Student());
            var student=viewModel.GetObjectFromCollection(collection);
            try
            {
                studentService.Add(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            StudentEditViewModel viewModel = new StudentEditViewModel(studentService.GetById(id));
            return View(viewModel);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            StudentEditViewModel viewModel = new StudentEditViewModel(studentService.GetById(id));
            var student=viewModel.GetObjectFromCollection(collection);
            try
            {
                studentService.Update(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new StudentDeleteViewModel(studentService.GetById(id));
            return View(model);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                studentService.Delete(studentService.GetById(id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
