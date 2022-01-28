using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleNote.Startup))]
namespace SimpleNote
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
