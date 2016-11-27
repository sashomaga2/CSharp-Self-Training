using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KatanaMvc.Startup))]
namespace KatanaMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
