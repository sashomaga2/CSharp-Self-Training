using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(food.Startup))]
namespace food
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
