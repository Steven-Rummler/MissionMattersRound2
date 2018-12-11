using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MissionMattersRound2.Startup))]
namespace MissionMattersRound2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
