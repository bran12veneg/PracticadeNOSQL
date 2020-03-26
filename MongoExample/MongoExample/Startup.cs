using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MongoExample.Startup))]
namespace MongoExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
