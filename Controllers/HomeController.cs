using Microsoft.AspNetCore.Mvc;
using SampleExam2020.Data;
using SampleExam2020.Entities;
using SampleExam2020.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleExam2020.Controllers
{
    public class HomeController : Controller
    {
        private StudentsDbContext _context;
        public HomeController(StudentsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ListStudentsVM lsVM = new ListStudentsVM();
            lsVM.AllStudents = _context.Students.ToList();

            return View(lsVM);
        }

        [HttpGet]

        public IActionResult Delete(int ID)
        {
            Student s = _context.Students.FirstOrDefault(st => st.ID == ID);

            if (s == null)
            {
                return RedirectToAction("Index", "Home");
            }

            _context.Students.Remove(s);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentVM stVM)
        {
            if (!ModelState.IsValid)
            {
                return View(stVM);
            }

            if (_context.Students.Count(s => s.Major.ToLower() == stVM.Major.ToLower()) > 10)
            {
                ModelState.AddModelError("error", "There are more than 10 students in this Major!");
                return View(stVM);
            }

            Student st = new Student
            {
                FacultyNumber = stVM.FacultyNumber,
                Major = stVM.Major,
                FirstName = stVM.FirstName,
                LastName = stVM.LastName
            };
            _context.Students.Add(st);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            Student st = _context.Students.FirstOrDefault(s => s.ID == ID);
            if (st == null)
            {
                return RedirectToAction("Index", "Home");
            }

            StudentVM stVM = new StudentVM
            {
                ID = st.ID,
                FacultyNumber = st.FacultyNumber,
                Major = st.Major,
                FirstName = st.FirstName,
                LastName = st.LastName
            };

            return View(stVM);
        }
        
        [HttpPost]
        public IActionResult Edit (StudentVM stVM)
        {
            Student st = _context.Students.FirstOrDefault(s => s.ID == stVM.ID);
            if (st == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (_context.Students.Count(s => s.Major.ToLower() == stVM.Major.ToLower()) > 10)
            {
                ModelState.AddModelError("error", "There are more than 10 students in this Major!");
                return View(stVM);
            }

            if (ModelState.IsValid)
            {
                st.FirstName = stVM.FirstName;
                st.LastName = stVM.LastName;
                st.FacultyNumber = stVM.FacultyNumber;
                st.Major = stVM.Major;

                _context.Students.Update(st);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(stVM);
        }
    }
}
