using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WindsorMvc.Startup))]
namespace WindsorMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
