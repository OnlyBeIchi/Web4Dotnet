using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Web4dotnet.StartupOwin))]

namespace Web4dotnet
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
