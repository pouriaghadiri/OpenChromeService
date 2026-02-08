using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting.WindowsServices;

var builder = Host.CreateApplicationBuilder(args);

// تبدیل به Windows Service
builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "TicketumAgentService";
});

// Worker اصلی
builder.Services.AddHostedService<Worker>();

// سرویس میزبان وب (API)
builder.Services.AddHostedService<WebApiHostService>();

var host = builder.Build();
host.Run();
