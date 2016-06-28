using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VendasASPNET.Startup))]
namespace VendasASPNET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
