using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SOEDU.Startup))]
namespace SOEDU
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
