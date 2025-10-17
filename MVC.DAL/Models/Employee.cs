using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DAL.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage ="Name Is Required")]
        public string Name { get; set; }
        [Range(22,60 , ErrorMessage ="Age Must Between 22 ,60")]
        public int? Age { get; set; }
        [DataType(DataType.EmailAddress,ErrorMessage = "Email Is Not Valid")]
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
        [MaxLength(50)]
        [Phone]
        public string phone { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        [DisplayName("Hiring Date")]
        public DateTime HiringDate { get; set; }
        [DisplayName("Date Of Create")]
        public DateTime CreatedAt { get; set; }

    }
}
