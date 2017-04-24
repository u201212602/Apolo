using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Apolo.Web.Startup))]
namespace Apolo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
