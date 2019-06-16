using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SaleTicket.Startup))]
namespace SaleTicket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
