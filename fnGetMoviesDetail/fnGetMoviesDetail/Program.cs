using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

//add dependencias do cosmosclient na raiz
builder.Services.AddSingleton(s =>
{
    string connectionString = Environment.GetEnvironmentVariable("CosmosDBConnection");
    return new CosmosClient(connectionString);
});

builder.Build().Run();
