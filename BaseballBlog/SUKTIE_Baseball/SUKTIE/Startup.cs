using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SUKTIE.Startup))]
namespace SUKTIE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
