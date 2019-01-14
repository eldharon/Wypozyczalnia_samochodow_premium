using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WypożyczalniaSamochodówPremium.Startup))]
namespace WypożyczalniaSamochodówPremium
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
