using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataBankProj.Startup))]
namespace DataBankProj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
