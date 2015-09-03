using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HumanResource.Web.Startup))]

namespace HumanResource.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuthentication(app);
        }
    }
}