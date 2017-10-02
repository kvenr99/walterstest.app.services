using System.Web.Http;
using WebActivatorEx;
using Company.Api;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Company.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

           

            GlobalConfiguration.Configuration
   .EnableSwagger(c =>
   {
       c.SingleApiVersion("v1", "CompanyApi");
       c.IncludeXmlComments(string.Format(@"{0}\bin\CompanyApi.XML",
                            System.AppDomain.CurrentDomain.BaseDirectory));
   })
   .EnableSwaggerUi();
        }
    }
}
