namespace Dev_Env_Exam_Project.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Role
    {
        public Role()
        {
            RoleOverviews = new List<RoleOverview>();
        }
        public int RoleId { get; set; }

        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public ICollection<RoleOverview> RoleOverviews { get; set; }

    }
}
