namespace Dev_Env_Exam_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PhoneNo = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId)
                .ForeignKey("dbo.Roles", t => t.CompanyId)
                .Index(t => t.CompanyId);

            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        email = c.String(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);

            CreateTable(
                "dbo.RoleOverviews",
                c => new
                    {
                        RoleOverviewId = c.Int(nullable: false, identity: true),
                        FocusYear = c.Int(nullable: false),
                        ExperienceLevel = c.String(),
                        FocusTime = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleOverviewId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.EmployeeId);

            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CompanyId = c.Int(nullable: false),
                        Company_CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.Companies", t => t.Company_CompanyId)
                .Index(t => t.Company_CompanyId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Companies", "CompanyId", "dbo.Roles");
            DropForeignKey("dbo.RoleOverviews", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Roles", "Company_CompanyId", "dbo.Companies");
            DropForeignKey("dbo.RoleOverviews", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Roles", new[] { "Company_CompanyId" });
            DropIndex("dbo.RoleOverviews", new[] { "EmployeeId" });
            DropIndex("dbo.RoleOverviews", new[] { "RoleId" });
            DropIndex("dbo.Employees", new[] { "CompanyId" });
            DropIndex("dbo.Companies", new[] { "CompanyId" });
            DropTable("dbo.Roles");
            DropTable("dbo.RoleOverviews");
            DropTable("dbo.Employees");
            DropTable("dbo.Companies");
        }
    }
}
