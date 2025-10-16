using Microsoft.EntityFrameworkCore;
using MVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DAL.Data
{
    public class CompanyMvcContext :DbContext
    {
        public CompanyMvcContext(DbContextOptions<CompanyMvcContext> options) :base(options)
        {
            
        }
        public DbSet<Department> Departments { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=WIN-Q618B842NC4\\SQLEXPRESS;Initial Catalog=CompanyMvc;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        //}
    }
}
