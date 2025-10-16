using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Details(int id) 
        {
            var model = _departmentRepo.Get(id);
            return View(model);
        }

        //Edit Item
       
        public IActionResult Edit(int id) 
        {
            var model = _departmentRepo.Get(id);
            return View(model);
        }

        //Edit Item
        [HttpPost]
        public IActionResult Update(Department department)
        {
            if (ModelState.IsValid) 
            {
                int rowAffected = _departmentRepo.Update(department);
                if (rowAffected >0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View("Edit",department);
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var model = _departmentRepo.Get(id);
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
