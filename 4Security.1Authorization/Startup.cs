using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_4Security._1Authorization.Startup))]
namespace _4Security._1Authorization
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
