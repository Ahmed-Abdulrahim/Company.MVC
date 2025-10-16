using MVC.BLL.Interfaces;
using MVC.DAL.Data;
using MVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BLL.Repo
{
    public class DepartmentRepo : IDepartmentModule
    {
        private readonly CompanyMvcContext _companyContext;
        public DepartmentRepo(CompanyMvcContext companyContext)
        {
            _companyContext = companyContext;
        }
        public IEnumerable<Department> GetAll() => _companyContext.Departments.ToList();


        public Department? Get(int id) => _companyContext.Departments.FirstOrDefault(d => d.Id == id);
        
        public int Add(Department model)
        {
            _companyContext.Departments.Add(model);
            return _companyContext.SaveChanges();
        }
        public int Update(Department model)
        {
            _companyContext.Departments.Update(model);
            return _companyContext.SaveChanges();
        }
        public int Delete(Department model)
        {
            _companyContext.Departments.Remove(model);
            return _companyContext.SaveChanges();
        }


        

       
    }
}
