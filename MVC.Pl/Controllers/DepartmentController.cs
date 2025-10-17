using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using MVC.BLL.Interfaces;
using MVC.BLL.Repo;
using MVC.DAL.Models;

namespace MVC.Pl.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentModule _departmentRepo;
        public DepartmentController(IDepartmentModule departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }
        [HttpGet]
        //Department/Index
        public IActionResult Index()
        {
            var model=_departmentRepo.GetAll();
            return View(model);
        }

        //AddData From Form To Create Fun
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department model)
        {
            if (ModelState.IsValid) 
            {
               int RoWAffected  = _departmentRepo.Add(model);
                if (RoWAffected > 0) 
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        //Details
        [HttpGet]
        public IActionResult Details(int? id , string viewName = "Details") 
        {
            if (id == null) return BadRequest("Invalid Id");
            var model = _departmentRepo.Get(id.Value);
            if (model == null) return NotFound("Not Found");
            return View(viewName,model);
        }

        //Edit Item
        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            //if (id == null) return BadRequest("Invalid Id");
            //var model = _departmentRepo.Get(id.Value);
            //if (model == null) return NotFound("Not Found");
            return Details(id,"Edit");
        }

        //Edit Item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int? id,Department department)
        {
            if (ModelState.IsValid) 
            {
                if (id != department.Id) return BadRequest("NotFound");
                int rowAffected = _departmentRepo.Update(department);
                if (rowAffected >0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(department);
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(int? id) 
        {
            if (id == null) return BadRequest("Invalid Id");
            var model = _departmentRepo.Get(id.Value);
            if (model == null) 
            {
                return Content("No Id Found", contentType: "text/html");
            }
            int deleted = _departmentRepo.Delete(model);
            if (deleted == 0)
            {
                return Content("No Id Found for Model", contentType: "text/html");
            }
            return RedirectToAction("Index");

        }
    }
}
