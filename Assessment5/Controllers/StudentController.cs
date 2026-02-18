using Microsoft.AspNetCore.Mvc;
using Assessment.Models;
using System.Collections.Generic;

namespace Assessment.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var students = new List<Student>()
            {
                new Student{ StudentId = 1, Name="Jeet", Department="IT", Marks=85 },
                new Student{ StudentId = 2, Name="Saanvi", Department="CS", Marks=70 },
                new Student{ StudentId = 3, Name="Jay", Department="IT", Marks=90 }
            };

            return View(students);
        }

        public IActionResult Details(int id)
        {
            var student = new Student
            {
                StudentId = id,
                Name = "Jeet",
                Department = "IT",
                Marks = 85
            };

            return View(student);
        }
    }
}
