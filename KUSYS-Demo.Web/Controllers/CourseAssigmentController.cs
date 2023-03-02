using KUSYS_Demo.Business.Service;
using KUSYS_Demo.Data;
using KUSYS_Demo.Data.Models;
using KUSYS_Demo.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.Web.Controllers
{
    public class CourseAssigmentController : Controller
    {
        CourseAssigmentService courseAssigmentService;
        public CourseAssigmentController(Context context)
        {
            courseAssigmentService=new CourseAssigmentService(context);
        }
        public IActionResult List(int id)
        {
            List<CourseAssigmentListViewModel> courses = new List<CourseAssigmentListViewModel>();
            courseAssigmentService.GetCourseAssigmentsByStudent(id).ForEach(x => courses.Add(new CourseAssigmentListViewModel(x)));
            return PartialView(courses);
        }
        public ActionResult Assign(int id)
        {
            CourseAssigmentAssignViewModel viewModel = new CourseAssigmentAssignViewModel(courseAssigmentService.GetUnassignedCoursesByStudent(id),id);
            return PartialView(viewModel);
        }

        // POST: CourseAssigmentAssigment/Assign
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Assign(IFormCollection collection)
        {
            CourseAssigmentAssignViewModel viewModel = new CourseAssigmentAssignViewModel();
            var courseAssignment = viewModel.GetObjectFromCollection(collection);
            try
            {
                courseAssigmentService.Add(courseAssignment);
                return RedirectToAction("Edit","Student",new {id= courseAssignment.StudentId});
            }
            catch
            {
                return RedirectToAction("Edit","Student", new { id = courseAssignment.StudentId });
            }
        }

    }
}
