using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Adds.Web.Startup))]
namespace Adds.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
