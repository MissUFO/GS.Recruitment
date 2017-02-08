using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GS.Recruitment.Web.Startup))]
namespace GS.Recruitment.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
