using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventAttendanceAdmin.Web.Startup))]
namespace EventAttendanceAdmin.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
