using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DonaldsonMotors.Startup))]
namespace DonaldsonMotors
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
