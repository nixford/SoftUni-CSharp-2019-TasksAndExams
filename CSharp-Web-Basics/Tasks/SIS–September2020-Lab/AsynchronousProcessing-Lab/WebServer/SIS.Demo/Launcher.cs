﻿namespace SIS.Demo
{
    using HTTP.Enums;
    using WebServer;
    using WebServer.Routing;

    public class Launcher
    {
        public static void Main()
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable
                .Routes[HttpRequestMethod.Get]["/"] = 
                request => new HomeController().Index(request);

            Server server = new Server(8000, serverRoutingTable);

            server.Run();
        }
    }
}