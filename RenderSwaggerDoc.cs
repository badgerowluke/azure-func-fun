using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Aliencube.AzureFunctions.Extensions.OpenApi;
using Aliencube.AzureFunctions.Extensions.OpenApi.Attributes;
using Aliencube.AzureFunctions.Extensions.OpenApi.Configurations;
using Aliencube.AzureFunctions.Extensions.OpenApi.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.OpenApi;

namespace func_swagger_test
{
    public class RenderSwaggerDoc
    {
        [FunctionName(nameof(RenderSwaggerDoc))]
        [OpenApiIgnore]
        public async Task<IActionResult> RenderSwaggerDocument(
                [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "swagger.json")] HttpRequest req)
        {
            var settings = new AppSettings();
            var filter = new RouteConstraintFilter();
            var helper = new DocumentHelper(filter);
            var document = new Document(helper);
            var result = await document.InitialiseDocument()
                                       .AddMetadata(settings.OpenApiInfo)
                                       .AddServer(req, "api")
                                       .Build(Assembly.GetExecutingAssembly())
                                       .RenderAsync(OpenApiSpecVersion.OpenApi2_0, OpenApiFormat.Json)
                                       .ConfigureAwait(false);
            var response = new ContentResult()
            {
                Content = result,
                ContentType = "application/json",
                StatusCode = (int)HttpStatusCode.OK
            };

            return response;
        }

        [FunctionName(nameof(RenderSwaggerUI))]
        [OpenApiIgnore]
        public async Task<IActionResult> RenderSwaggerUI(
                [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "swagger/ui")] HttpRequest req)
        {
            var settings = new AppSettings();
            var ui = new SwaggerUI();
            var result = await ui.AddMetadata(settings.OpenApiInfo)
                                 .AddServer(req, "")
                                 .BuildAsync()
                                 .RenderAsync("api/swagger.json", settings.SwaggerAuthKey)
                                 .ConfigureAwait(false);
            var response = new ContentResult()
            {
                Content = result,
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK
            };

            return response;
      
        }
    }
}