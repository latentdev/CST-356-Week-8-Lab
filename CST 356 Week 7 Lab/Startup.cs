using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CST_356_Week_7_Lab.Startup))]
namespace CST_356_Week_7_Lab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
