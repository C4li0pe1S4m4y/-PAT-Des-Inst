using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PATOnline.Startup))]
namespace PATOnline
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
