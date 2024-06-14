global using Lubee.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("Lubee/appsettings.json", optional: true, reloadOnChange: true)
                     .AddJsonFile($"Lubee/appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

var app = builder
  .ConfigureServices()
  .ConfigurePipeline();

app.Run();
