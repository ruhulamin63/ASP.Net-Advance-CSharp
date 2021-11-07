using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Uploadimage.Startup))]
namespace Uploadimage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
