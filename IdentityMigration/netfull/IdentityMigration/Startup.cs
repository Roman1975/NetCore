using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityMigration.Startup))]
namespace IdentityMigration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
