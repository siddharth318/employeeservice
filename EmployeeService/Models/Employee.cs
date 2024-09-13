using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EmployeeService.Models
{
    public enum EmployeeDesignation{
        Manager,
        Employee
    }

    public class Employee
    {



        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }



        //[Key]
        //  public int Id { get; set; }
        //[Required]
        // public string Name { get; set; }
        //[Required]
        // public string Designation { get; set; }
        //[Required]
        //[StringLength(10)]
        //public string Phone { get; set; }
        //[Required]
        // public string Email { get; set; }
        //[Required]
        //[PasswordPropertyText]
        //[StringLength(10)]
        // public string Password { get; set; }
    }
}
