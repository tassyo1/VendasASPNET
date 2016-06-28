using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VendasASP.NET.Startup))]
namespace VendasASP.NET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
