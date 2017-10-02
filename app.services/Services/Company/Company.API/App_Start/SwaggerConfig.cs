using System.Web.Http;
using WebActivatorEx;
using UserServices;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace UserServices
{/// <summary>
/// 
/// </summary>
    public class SwaggerConfig
    {/// <summary>
    /// 
    /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
   .EnableSwagger(c =>
   {
       c.SingleApiVersion("v1", "SwaggerDemoApi");
       c.IncludeXmlComments(string.Format(@"{0}\bin\SwaggerDemoApi.XML",
                            System.AppDomain.CurrentDomain.BaseDirectory));
   })
   .EnableSwaggerUi();
        }
    }
}
