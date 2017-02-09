using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dev_Env_Exam_Project.Startup))]
namespace Dev_Env_Exam_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
