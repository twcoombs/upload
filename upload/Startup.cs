using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(upload.Startup))]
namespace upload
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
