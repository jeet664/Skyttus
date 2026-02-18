using Microsoft.AspNetCore.Mvc;
using Assessment6.Models;
using System.Collections.Generic;
using System.Linq;

namespace Assessment6.Controllers
{
    public class AssessmentController : Controller
    {
        private static List<Assessment> assessments = new List<Assessment>();

        // READ
        public IActionResult Index()
        {
            return View(assessments);
        }

        // CREATE - GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE - POST
        [HttpPost]
        public IActionResult Create(Assessment assessment)
        {
            if (ModelState.IsValid)
            {
                assessment.Id = assessments.Count + 1;
                assessments.Add(assessment);
                return RedirectToAction("Index");
            }
            return View(assessment);
        }

        // EDIT - GET
        public IActionResult Edit(int id)
        {
            var assessment = assessments.FirstOrDefault(a => a.Id == id);
            return View(assessment);
        }

        // EDIT - POST
        [HttpPost]
        public IActionResult Edit(Assessment assessment)
        {
            if (ModelState.IsValid)
            {
                var existing = assessments.FirstOrDefault(a => a.Id == assessment.Id);

                existing.Title = assessment.Title;
                existing.Subject = assessment.Subject;
                existing.TotalMarks = assessment.TotalMarks;

                return RedirectToAction("Index");
            }
            return View(assessment);
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var assessment = assessments.FirstOrDefault(a => a.Id == id);
            assessments.Remove(assessment);
            return RedirectToAction("Index");
        }
    }
}
