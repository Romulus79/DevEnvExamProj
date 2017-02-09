using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dev_Env_Exam_Project.Models
{
    public class CompanyRoleViewModel
    {
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}