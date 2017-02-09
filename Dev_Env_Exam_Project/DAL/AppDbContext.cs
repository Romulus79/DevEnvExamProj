using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Dev_Env_Exam_Project.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleOverview> RoleOverviews { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public AppDbContext() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Role>()
                .HasRequired(d => d.Company)
                .WithMany(w => w.Roles)
                .HasForeignKey(d => d.CompanyId)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Company>().Property(p => p.CompanyId).HasDatabaseGeneratedOption(DatabaseGeneratedOpt‌​ion.Identity);
        }


    }
}