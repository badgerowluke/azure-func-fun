using Aliencube.AzureFunctions.Extensions.Configuration.AppSettings;
using Microsoft.OpenApi.Models;

namespace func_swagger_test
{
    public class AppSettings : AppSettingsBase
    {
        public AppSettings()
        {

            var openApiInfo = new OpenApiInfo();
            openApiInfo.Description = "A demonstration of hooking up to funcs with AutoRest";// this.Config["OpenApi:Info:Description"];
            openApiInfo.Version = "0.0.1";// this.Config["OpenApi:Info:Version"];
            openApiInfo.Title = "a super snazzy title";//this.Config["OpenApi:Info:Title"]
            this.OpenApiInfo = openApiInfo;
            this.SwaggerAuthKey = this.Config["OpenApi:AuthKey"];
        }
        public OpenApiInfo OpenApiInfo { get; }
        public string SwaggerAuthKey { get; }
    }    
}