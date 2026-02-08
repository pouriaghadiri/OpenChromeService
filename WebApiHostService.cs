using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

public class WebApiHostService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // ساخت Host برای Web API
        var webHost = new HostBuilder()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseKestrel()
                          .UseUrls("http://0.0.0.0:5050")
                          .Configure(app =>
                          {
                              // فعال کردن Routing
                              app.UseRouting();

                              // تعریف Endpoint ها
                              app.UseEndpoints(endpoints =>
                              {
                                  endpoints.MapPost("/open-chrome", async context =>
                                  {
                                      try
                                      {
                                          // خواندن JSON body
                                          var body = await context.Request.ReadFromJsonAsync<UrlRequest>();
                                          if (body?.Url == null)
                                          {
                                              context.Response.StatusCode = 400;
                                              await context.Response.WriteAsync("Invalid request");
                                              return;
                                          }

                                          string taskName = "OpenChromeTask";
                                          string chromePath = "chrome.exe"; // یا مسیر کامل Chrome
                                          string url = body.Url;

                                          // 1️⃣ حذف Task قبلی اگر وجود داشت
                                          Process.Start(new ProcessStartInfo
                                          {
                                              FileName = "schtasks",
                                              Arguments = $"/delete /tn {taskName} /f",
                                              CreateNoWindow = true,
                                              UseShellExecute = false
                                          })?.WaitForExit();

                                          // 2️⃣ ایجاد Task جدید
                                          Process.Start(new ProcessStartInfo
                                          {
                                              FileName = "schtasks",
                                              Arguments = $"/create /tn {taskName} /tr \"{chromePath} {url}\" /sc once /st 00:00 /RL HIGHEST /F",
                                              CreateNoWindow = true,
                                              UseShellExecute = false
                                          })?.WaitForExit();

                                          // 3️⃣ اجرای Task
                                          Process.Start(new ProcessStartInfo
                                          {
                                              FileName = "schtasks",
                                              Arguments = $"/run /tn {taskName}",
                                              CreateNoWindow = true,
                                              UseShellExecute = false
                                          })?.WaitForExit();

                                          // پاسخ موفق
                                          context.Response.StatusCode = 200;
                                          await context.Response.WriteAsync($"Chrome task scheduled and running: {url}");
                                      }
                                      catch
                                      {
                                          context.Response.StatusCode = 500;
                                          await context.Response.WriteAsync("Error scheduling Chrome");
                                      }
                                  });
                              });
                          });
            })
            .Build();

        // اجرای Host
        await webHost.RunAsync(stoppingToken);
    }

    // کلاس برای JSON body
    public record UrlRequest(string Url);
}
