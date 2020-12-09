using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RealTalk.Startup))]
namespace RealTalk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
