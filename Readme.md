# Azure Functions Swagger Generation

[Rules for DI in Azure Func](https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection)


[Azure Functions OpenApi documentation](https://github.com/aliencube/AzureFunctions.Extensions/blob/dev/docs/openapi.md)


[AutoRest](https://github.com/Azure/autorest)


```powershell
autorest 
--input-file=http://localhost:7071/api/swagger 
--csharp 
--output-folder=cshsarp 
--namespace=Insight.DI.Demo 
--override-client-name=InsightDigitalInnovation
```