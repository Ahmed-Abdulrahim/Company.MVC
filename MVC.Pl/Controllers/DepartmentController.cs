using Microsoft.AspNetCore.Mvc;
using MVC.BLL.Repo;

namespace MVC.Pl.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentRepo _departmentRepo;
        public DepartmentController(DepartmentRepo departmentRepo)
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
