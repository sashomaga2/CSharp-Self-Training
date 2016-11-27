using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TempMvc.Startup))]
namespace TempMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
