using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Restapp.Startup))]
namespace Restapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
