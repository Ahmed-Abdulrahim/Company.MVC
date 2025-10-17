using Microsoft.AspNetCore.Mvc;
using MVC.BLL.Interfaces;
using MVC.DAL.Models;

namespace MVC.Pl.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEntityType<Employee> employeeRepo;
        private readonly IEntityType<Department> deptRepo;


        public EmployeeController(IEntityType<Employee> _employee , IEntityType<Department> _dept)
        {
            employeeRepo = _employee;
            deptRepo = _dept;
        }
        //Display All Data
        public IActionResult Index()
        {
             var model = employeeRepo.GetAll();
            return View(model);
        }

        //Add Department
        [HttpGet]
        public IActionResult Create() 
        {
            var DeptList = deptRepo.GetAll();
            ViewData["Dept"] = DeptList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid) 
            {
                var rowAffected = employeeRepo.Add(model);
                if (rowAffected > 0) 
                {
                  return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        //Details
        [HttpGet]
        public IActionResult Details(int? id) 
        {
           
            if (id == null) return NotFound();
            var Emp = employeeRepo.Get(id.Value);
            if(Emp== null)return BadRequest();
            return View(Emp);
        }

        //Edit
        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            var DeptList = deptRepo.GetAll();
            ViewData["Dept"] = DeptList;
            if (id == null) return NotFound();
            var Emp = employeeRepo.Get(id.Value);
            if(Emp==null)return BadRequest();
            return View(Emp);
        }

        //Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int? id , Employee model)
        {
            if (ModelState.IsValid) 
            {
                if (id != model.Id) return BadRequest();
                if (model == null) return NotFound();
                var rowAffected = employeeRepo.Update(model);
                if (rowAffected > 0) return RedirectToAction("Index");
            }
            return View(model);
        }

        //Delete
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if(id == null) return NotFound();
            var Emp = employeeRepo.Get(id.Value);
            if(Emp== null) return BadRequest();
            var rowAffected = employeeRepo.Delete(Emp);
            if (rowAffected > 0) return RedirectToAction("Index");
            return Content("Failed To Delete", contentType: "text/html");
        }
    }
}
