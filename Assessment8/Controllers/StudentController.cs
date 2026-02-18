using Microsoft.AspNetCore.Mvc;
using Assessment8.Models;
using Assessment8.Repositories;

namespace Assessment8.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repository;

        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(student);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Edit(int id)
        {
            return View(_repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(student);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            return View(_repository.GetById(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}
