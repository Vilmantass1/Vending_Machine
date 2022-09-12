using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Vending_Machine;

using IHost host = Host.CreateDefaultBuilder(args)
                       //.ConfigureAppConfiguration(app => app.AddJsonFile("appsettings.json"))
    .ConfigureServices((host, services) =>
    {
        var config = host.Configuration;


        services.AddScoped<IExecutor, Executor>();
    })
    .Build();

 host.Services.GetRequiredService<IExecutor>().Run();
