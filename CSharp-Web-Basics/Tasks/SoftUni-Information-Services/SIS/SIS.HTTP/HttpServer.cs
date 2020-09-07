using SIS.HTTP.Enums;
using SIS.HTTP.HttpElements;
using SIS.HTTP.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private readonly IList<Route> routeTable;
        private readonly IDictionary<string, IDictionary<string, string>> sessions;

        // TODO: actions
        public HttpServer(int port, IList<Route> routeTable)
        {
            this.tcpListener = new TcpListener(IPAddress.Loopback, port);            
            this.routeTable = routeTable;
            this.sessions = new Dictionary<string, IDictionary<string, string>>();
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
                try
                {
                    byte[] requestBytes = new byte[1000000]; // standart 4096
                    int bytesRead = await networkStream.ReadAsync(requestBytes, 0, requestBytes.Length);
                    string requestAsString = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);

                    var request = new HttpRequest(requestAsString);
                    var sessionCookie = request.Cookies.FirstOrDefault(x => x.Name == HttpConstants.SessionIdCookieName);
                    
                    string newSessionId = null;

                    if (sessionCookie != null && this.sessions.ContainsKey(sessionCookie.Value))
                    {
                        request.SessionData = this.sessions[sessionCookie.Value];
                    }
                    else
                    {
                        newSessionId = Guid.NewGuid().ToString();
                        var dictionary = new Dictionary<string, string>();
                        this.sessions.Add(newSessionId, dictionary);
                        request.SessionData = dictionary;
                    }

                    Console.WriteLine($"{request.Method} {request.Path}");
                    Console.WriteLine(new string('=', 60));

                    var route = this.routeTable.FirstOrDefault(x => x.HttpMethod == request.Method &&
                    x.Path == request.Path);
                    HttpResponse response;
                    if (route == null)
                    {
                        response = new HttpResponse(HttpResponseCode.NotFound, new byte[0]);
                    }
                    else
                    {
                        response = route.Action(request);
                    }
                    
                    response.Headers.Add(new Header("Server", "Server: SoftUniServer/1.0"));

                    
                    if (newSessionId != null)
                    {
                        newSessionId = Guid.NewGuid().ToString();
                        this.sessions.Add(newSessionId, new Dictionary<string, string>());

                        response.Cookies.Add(new ResponceCooke(HttpConstants.SessionIdCookieName, newSessionId)
                        { HttpOnly = true, MaxAge = 30*3600, });
                    }
                    

                    byte[] resposeBytes = Encoding.UTF8.GetBytes(response.ToString());
                    await networkStream.WriteAsync(resposeBytes, 0, resposeBytes.Length);
                    await networkStream.WriteAsync(response.Body, 0, response.Body.Length);                    
                }
                catch (Exception ex)
                {
                    var errorResponse = new HttpResponse
                        (HttpResponseCode.InternalServerError, 
                        Encoding.UTF8.GetBytes(ex.ToString()));

                    errorResponse.Headers.Add(new Header("Content-Type", "text/plain"));
                    byte[] resposeBytes = Encoding.UTF8.GetBytes(errorResponse.ToString());
                    await networkStream.WriteAsync(resposeBytes, 0, resposeBytes.Length);
                    await networkStream.WriteAsync(errorResponse.Body, 0, errorResponse.Body.Length);
                }
            }
        }
    }
}
