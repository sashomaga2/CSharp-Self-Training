using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RolesTest.Startup))]
namespace RolesTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
