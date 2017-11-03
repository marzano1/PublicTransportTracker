using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PublicTransportTracker.Startup))]
namespace PublicTransportTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
