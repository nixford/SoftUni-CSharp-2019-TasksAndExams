using SIS.HTTP.Enums;
using SIS.HTTP.HttpElements;
using SIS.HTTP.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SIS.HTTP
{
    // if we use netstandart2.1 instead 2.0 we shall limit the applications, which will be
    // able to use our application (the older version - the wider range of applications)
    public class HttpServer : IHttpServer
    {
        private readonly TcpListener tcpListener;

        public HttpServer()
        {
        }

        // TODO: actions
        public HttpServer(int port)
        {
            this.tcpListener = new TcpListener(IPAddress.Loopback, port);
            
        }

        public async Task ResetAsync()
        {
            this.Stop();
            await this.StartAsync();
        }

        public async Task StartAsync()
        {
            this.tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                Task.Run(() => ProcessClientAsync(tcpClient));
            }
        }

        public void Stop()
        {
            this.tcpListener.Stop();
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            using (NetworkStream networkStream = tcpClient.GetStream())
            {
                byte[] requestBytes = new byte[1000000]; // standart 4096
                int bytesRead = await networkStream.ReadAsync(requestBytes, 0, requestBytes.Length);
                string requestAsString = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);

                var request = new HttpRequest(requestAsString);
                string content = "<h1>random page<h1>";
                if (request.Path == "/")
                {
                    content = "<h1>home page</h1>";
                }
                else if (request.Path == "/users/login")
                {
                    content = "<h1>login page</h1>";
                }

                byte[] stringContent = Encoding.UTF8.GetBytes(content);

                var response = new HttpResponse(HttpResponseCode.Ok, stringContent);
                response.Headers.Add(new Header("Server", "Server: SoftUniServer/1.0"));
                response.Headers.Add(new Header("Content-Type:", "text/html"));                
                byte[] resposeBytes = Encoding.UTF8.GetBytes(response.ToString());
                await networkStream.WriteAsync(resposeBytes, 0, resposeBytes.Length);
                await networkStream.WriteAsync(response.Body, 0, response.Body.Length);

                Console.WriteLine(requestAsString);
                File.WriteAllText("../../../requestOutput.txt", requestAsString);
                Console.WriteLine(new string('=', 60));
            }
        }
    }
}
