using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UltimateRevisionPlannerWebsite.Startup))]
namespace UltimateRevisionPlannerWebsite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
