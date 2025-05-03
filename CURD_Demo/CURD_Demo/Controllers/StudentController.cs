using CURD_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using CURD_Demo.Repositories;
using CURD_Demo.DBContext;

namespace CURD_Demo.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepo _studentRepo;

        public StudentController(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }
        public IActionResult Student()
        {
            var students = _studentRepo.GetAll();
            return View(students);
        }
        public IActionResult Details(int id)
        {
            var student = _studentRepo.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepo.Add(student);
                return RedirectToAction(nameof(Student));
            }
            return View(student);
        }
        public IActionResult Edit(int id)
        {
            var student = _studentRepo.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepo.Update(student);
                return RedirectToAction(nameof(Student));
            }
            return View(student);
        }
        public IActionResult Delete(int id)
        {
            var student = _studentRepo.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _studentRepo.Delete(id);
            return RedirectToAction(nameof(Student));
        }
    }
}
