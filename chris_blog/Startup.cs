using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(chris_blog.Startup))]
namespace chris_blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
