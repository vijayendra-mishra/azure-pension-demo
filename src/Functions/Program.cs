using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Application.Queries;
using Microsoft.Extensions.Logging;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetPensionQuery).Assembly));
    })
    .ConfigureLogging(logging =>
    {
        logging.AddConsole();
    })
    .Build();

host.Run();
