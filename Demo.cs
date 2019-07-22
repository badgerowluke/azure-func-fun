using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Aliencube.AzureFunctions.Extensions.OpenApi.Attributes;

namespace func_swagger_test
{
    public class Demo
    {
        public Demo()
        {
            
        }

        [FunctionName("Demo")]
        [OpenApiOperation("Demo", Summary="pasta", Description="just the default function")]
        [OpenApiParameter("email", Required=true, Description="just do it", Type=typeof(string))]
        public async Task<IActionResult> SayHello(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];


            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
        [FunctionName("Stuff")]
        [OpenApiOperation("Demo-Post")]
        [OpenApiRequestBody("application/json", typeof(PostRequest))]
        
        public async Task<IActionResult> SayHelloPost([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route="Demo")] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");

        }
    

    }
}
