using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_Env_Exam_Project.Models
{
    public class RoleOverview
    {
        public int RoleOverviewId { get; set; }

        public int FocusYear { get; set; }

        public string ExperienceLevel { get; set; }

        public int FocusTime { get; set; }

        public int RoleId { get; set; }
        public int EmployeeId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
