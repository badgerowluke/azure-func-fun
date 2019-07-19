using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.Services.AppAuthentication;

[assembly: FunctionsStartup(typeof(func_swagger_test.Startup))]
namespace func_swagger_test
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

        }
    }
}