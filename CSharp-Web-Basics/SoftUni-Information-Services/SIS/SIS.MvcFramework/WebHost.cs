using SIS.HTTP;
using SIS.HTTP.Enums;
using SIS.HTTP.HttpElements;
using SIS.HTTP.Response;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SIS.MvcFramework
{
    public static class WebHost
    {
        public static async Task StartAsync(IMvcApplication application)
        {
            var routeTable = new List<Route>();
            application.ConfigureServices(); 
            application.Configure(routeTable);
            AutoRegisterStaticFilesRoutes(routeTable);
            AutoRegisterActionRoutes(routeTable, application);

            Console.WriteLine("Registered routes:");
            foreach (var route in routeTable)
            {
                Console.WriteLine(route);
            }
            Console.WriteLine();
            Console.WriteLine("Requests:");
            var httpServer = new HttpServer(80, routeTable);
            await httpServer.StartAsync();
        }

        private static void AutoRegisterActionRoutes(List<Route> routeTable, IMvcApplication application)
        {
            throw new NotImplementedException();
        }

        private static void AutoRegisterStaticFilesRoutes(List<Route> routeTable)
        {
            var staticFiles = Directory.GetFiles("wwwroot", "*", SearchOption.AllDirectories);

            foreach (var staticFile in staticFiles)
            {
                var path = staticFile.Replace("wwwroot", string.Empty).Replace("\\", "/");
                routeTable.Add(new Route(HttpMethodType.Get, path, (request) =>
                {
                    var fileInfo = new FileInfo(staticFile);
                    var cotentType = fileInfo.Extension switch
                    {
                        ".css" => "text/css",
                        ".html" => "text/html",
                        ".js" => "text/javascript",
                        ".ico" => "image/x-icon",
                        ".jpg" => "image/jpeg",
                        ".jpeg" => "image/jpeg",
                        ".png" => "image/png",
                        ".gif" => "image/gif",
                        _ => "text/plain",
                    };


                    return new FileResponse(File.ReadAllBytes(staticFile), cotentType);
                }));
            }                        
        }
    }
}
