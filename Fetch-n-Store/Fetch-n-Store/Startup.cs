using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fetch_n_Store.Startup))]
namespace Fetch_n_Store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
