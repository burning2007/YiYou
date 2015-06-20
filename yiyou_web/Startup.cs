using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ICUPro.Portal.Startup))]
namespace ICUPro.Portal
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
