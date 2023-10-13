using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.Net;
using System.Reflection;

namespace TXViewer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Task.Run(() => StartWebServer());
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        private static void StartWebServer()
        {
            var assembly = Assembly.Load("TXTextControl.Web.MVC.DocumentViewer");

            var builder = WebHost.CreateDefaultBuilder();
            var app = builder
              .UseKestrel(options => options.Listen(IPAddress.Parse("127.0.0.1"), 8888))
              .UseContentRoot(Directory.GetCurrentDirectory())
              .UseWebRoot(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"))
              .ConfigureServices((services) =>
              {
                  services.AddCors();
                  services.AddMvc().AddMvcOptions(options =>
                  {
                      options.EnableEndpointRouting = false;
                  }).AddApplicationPart(assembly);
              })
              .Configure(app =>
              {
                  app.UseHttpsRedirection();

                  app.UseRouting();
                  
                  app.UseCors(builder =>
                  {
                      builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
                  });

                  app.UseAuthorization();

                  app.UseStaticFiles(new StaticFileOptions()
                  {
                      FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
                      RequestPath = ""
                  });

                  app.UseMvcWithDefaultRoute();

              }).Build();

            app.Run();
        }
    }

    
}