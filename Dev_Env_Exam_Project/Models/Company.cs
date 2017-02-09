using System.ComponentModel.DataAnnotations;

namespace Dev_Env_Exam_Project.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Company
    {

        //public Company()
        //{
        //    //Roles = new List<Role>();
        //    //Employees = new List<Employee>();
        //}
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }
        //public string Logo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Your must provide a PhoneNumber")]
        [Display(Name = "Phone Number")]
        //[DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+[0-9]{10}|[0-9]{8})$", ErrorMessage = "Not a valid Phone number! Expected format : \"+ country code and digits\" or \"8 digits\"")]
        public string PhoneNo { get; set; }
        [Required]
        public string Email { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
