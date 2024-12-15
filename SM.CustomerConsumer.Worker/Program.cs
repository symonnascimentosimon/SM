using SM.CustomerConsumer.Infra.IoC;
using SM.CustomerConsumer.Worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
DependencyInjection.BusConnectionService(builder.Services, builder.Configuration);
var host = builder.Build();
host.Run();