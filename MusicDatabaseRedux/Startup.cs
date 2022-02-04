using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MusicDatabaseRedux.Startup))]

namespace MusicDatabaseRedux
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}