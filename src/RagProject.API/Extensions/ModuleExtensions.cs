using RagProject.API.Contracts;
using System.Reflection;

namespace RagProject.API.Extensions
{
    public static class ModuleExtensions
    {
        public static WebApplication RegisterEndpoints(
        this WebApplication app)
        {
            var modules = app.Services.GetServices<IModule>();

            foreach (var module in modules)
            {
                module.RegisterEndpoints(app);
            }

            return app;
        }
    }

}
