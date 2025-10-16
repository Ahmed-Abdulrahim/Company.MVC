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
    }
}
