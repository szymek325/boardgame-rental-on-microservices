using System.Web.Http;
using WebActivatorEx;
using BoardGameRentalApp.Web;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace BoardGameRentalApp.Web
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "BoardGameRentalApp.Web");
                    })
                .EnableSwaggerUi(c =>
                    { 
                    });
        }
    }
}
