using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InterviewTask.Startup))]
namespace InterviewTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
