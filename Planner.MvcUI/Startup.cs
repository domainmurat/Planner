using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Planner.MvcUI.Startup))]
namespace Planner.MvcUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
