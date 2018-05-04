using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EfficiencyMVC.Startup))]
namespace EfficiencyMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
