using Aliencube.AzureFunctions.Extensions.Configuration.AppSettings;
using Microsoft.OpenApi.Models;

namespace func_swagger_test
{
    public class AppSettings : AppSettingsBase
    {
        public AppSettings()
        {

            var openApiInfo = new OpenApiInfo();
            openApiInfo.Description = this.Config["OpenApi:Info:Description"];
            openApiInfo.Version = this.Config["OpenApi:Info:Version"];
            openApiInfo.Title = this.Config["OpenApi:Info:Title"];
            this.OpenApiInfo = openApiInfo;
            this.SwaggerAuthKey = this.Config["OpenApi:AuthKey"];
        }
        public OpenApiInfo OpenApiInfo { get; }
        public string SwaggerAuthKey { get; }
    }    
}