using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(The_NewYork_Time.Startup))]
namespace The_NewYork_Time
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
