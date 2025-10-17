using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
    public class EmployeeRepo : IEntityType<Employee>
    {
        private readonly CompanyMvcContext companyDbContext;

        public EmployeeRepo(CompanyMvcContext _companyDbContext)
        {
            companyDbContext = _companyDbContext;
        }
        public IEnumerable<Employee> GetAll() => companyDbContext.Employees.Include(d=>d.Departments).ToList();

        public Employee? Get(int id) => companyDbContext.Employees.Include(d=>d.Departments).FirstOrDefault(d => d.Id == id);


        public int Add(Employee model)
        {
            var Emp = companyDbContext.Employees.Add(model);
            return companyDbContext.SaveChanges();
        }
        public int Update(Employee model)
        {
            var Emp = companyDbContext.Employees.Update(model);
            return companyDbContext.SaveChanges();
        }
        public int Delete(Employee model)
        {
            var Emp = companyDbContext.Employees.Remove(model);
            return companyDbContext.SaveChanges();
        }

      

      

       
    }
}
