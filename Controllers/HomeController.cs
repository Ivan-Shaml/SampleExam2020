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
      
        [HttpGet]
        public IActionResult Index()
        {
            StudentsDbContext context = new StudentsDbContext();

            ListStudentsVM lsVM = new ListStudentsVM();
            lsVM.AllStudents = context.Students.ToList();

            return View(lsVM);
        }

        [HttpGet]

        public IActionResult Delete(int ID)
        {
            StudentsDbContext context = new StudentsDbContext();

            Student s = context.Students.FirstOrDefault(st => st.ID == ID);

            if (s == null)
            {
                return RedirectToAction("Index", "Home");
            }

            context.Students.Remove(s);
            context.SaveChanges();

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

            StudentsDbContext context = new StudentsDbContext();

            if (context.Students.Count(s => s.Major.ToLower() == stVM.Major.ToLower()) > 10)
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
            context.Students.Add(st);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            StudentsDbContext context = new StudentsDbContext();

            Student st = context.Students.FirstOrDefault(s => s.ID == ID);
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
            StudentsDbContext context = new StudentsDbContext();

            Student st = context.Students.FirstOrDefault(s => s.ID == stVM.ID);
            if (st == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (context.Students.Count(s => s.Major.ToLower() == stVM.Major.ToLower()) > 10)
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

                context.Students.Update(st);
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(stVM);
        }
    }
}
