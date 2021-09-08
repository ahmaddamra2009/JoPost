using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCore1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore1.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext db;
        public EmployeesController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult AllEmployees()
        {
            if (HttpContext.Session.GetString("uName")!=null)
            {
                var obj = db.Employees.Where(x => x.isDeleted == false).Include(d => d.Department).ToList();
                return View(obj);
            }
            return RedirectToAction("Login", "Account");
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DeptList = new SelectList(db.Departments.Where(x=>x.isDeleted==false), "Id", "DepartmentName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("AllEmployees");
            }
            ViewBag.DeptList = new SelectList(db.Departments.Where(x => x.isDeleted == false), "Id", "DepartmentName");
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = db.Employees.Find(id);
            ViewBag.DeptList = new SelectList(db.Departments.Where(x => x.isDeleted == false), "Id", "DepartmentName");
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Update(employee);
                db.SaveChanges();
                return RedirectToAction("AllEmployees");
            }
            ViewBag.DeptList = new SelectList(db.Departments.Where(x => x.isDeleted == false), "Id", "DepartmentName");
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete (int id)
        {
            var data = db.Employees.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            
                var data = db.Employees.Find(employee.EmployeeId);
                db.Employees.Remove(data);
                db.SaveChanges();
                return RedirectToAction("AllEmployees");
           
        }


        [HttpGet]
        public IActionResult Delete2(int id)
        {
            var data = db.Employees.Find(id);
            ViewBag.DeptList = new SelectList(db.Departments.Where(x => x.isDeleted == false), "Id", "DepartmentName");
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete2(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var data = db.Employees.Find(employee.EmployeeId);
                data.isDeleted = true;
                db.Employees.Update(data);
                db.SaveChanges();
                return RedirectToAction("AllEmployees");
            }
            ViewBag.DeptList = new SelectList(db.Departments.Where(x => x.isDeleted == false), "Id", "DepartmentName");
            return View(employee);
        }
    }
}
