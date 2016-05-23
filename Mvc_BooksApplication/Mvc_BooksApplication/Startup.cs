using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mvc_BooksApplication.Startup))]
namespace Mvc_BooksApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
