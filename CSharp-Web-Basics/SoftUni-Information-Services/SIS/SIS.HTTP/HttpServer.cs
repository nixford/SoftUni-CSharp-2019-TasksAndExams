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
            const string NewLine = "\r\n";

            using (NetworkStream networkStream = tcpClient.GetStream())
            {
                byte[] requestBytes = new byte[1000000]; // standart 4096
                int bytesRead = await networkStream.ReadAsync(requestBytes, 0, requestBytes.Length);
                string request = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);
                byte[] fileContent = Encoding.UTF8.GetBytes("<h1>Hellow, World!</h1>");                 
                string headers = " HTTP/1.0 200 OK" + NewLine +                                   
                                   "Server: SoftUniServer/1.0" + NewLine +
                                   "Content-Type: text/html" + NewLine +
                                   "Content-Lenght: " + fileContent.Length + NewLine + 
                                   NewLine;
                byte[] headersBytes = Encoding.UTF8.GetBytes(headers);
                await networkStream.WriteAsync(headersBytes, 0, headersBytes.Length);
                await networkStream.WriteAsync(fileContent, 0, fileContent.Length);

                Console.WriteLine(request);
                Console.WriteLine(new string('=', 60));
            }
        }
    }
}
