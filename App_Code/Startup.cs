using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CCN.Startup))]
namespace CCN
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
