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
using Microsoft.OpenApi.Models;

namespace func_swagger_test
{
    
    public class Demo
    {
        public Demo() { }

        [FunctionName("SayHello")]
        [OpenApiOperation("SayHello", Summary="your name", Description="just the default function")]
        [OpenApiParameter("name", In=ParameterLocation.Query, Required=true, Description="we need to know who to say hello too.", Type=typeof(string))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.NoContent, "application/json", typeof(string))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.InternalServerError, "application/json", typeof(string))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.BadRequest, "application/json", typeof(string))]
        [OpenApiResponseBody(System.Net.HttpStatusCode.OK, "application/json", typeof(string))]
        public async Task<IActionResult> SayHello(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "SayHello")] HttpRequest req,
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
    }
}
