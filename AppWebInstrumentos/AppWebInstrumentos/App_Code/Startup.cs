using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppWebInstrumentos.Startup))]
namespace AppWebInstrumentos
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
