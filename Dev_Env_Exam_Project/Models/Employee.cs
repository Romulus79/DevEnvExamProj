using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dev_Env_Exam_Project.Models
{
    public class Employee
    {
        public Employee()
        {
            RoleOverviews = new List<RoleOverview>();
        }
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }

        [Required(ErrorMessage = "Your must provide a PhoneNumber")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+[0-9]{10}|[0-9]{8})$",
            ErrorMessage = "Not a valid Phone number! Expected format : \"+ country code and digits\" or \"8 digits\"")]
        public string Phone { get; set; }
        [Required]
        public string email { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public ICollection<RoleOverview> RoleOverviews { get; set; }
    }
}