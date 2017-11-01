using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Learning_Path.Startup))]
namespace Learning_Path
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
