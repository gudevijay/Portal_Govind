using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DBPortal.Startup))]
namespace DBPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
