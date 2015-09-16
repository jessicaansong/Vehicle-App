using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarList.Startup))]
namespace CarList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
