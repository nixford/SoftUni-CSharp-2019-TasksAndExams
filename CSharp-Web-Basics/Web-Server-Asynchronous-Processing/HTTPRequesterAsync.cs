using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HTTPRequesterAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            

            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 1234); // Default port is 80
            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                Task.Run(() => ProcessClientAsync(tcpClient));
                // The Task.Run() initiate the method ProcessClientAsync(tcpClient) to work immediately after
                // requst from client, whithout the need to wait the same method to finish with
                // the first (or the previuos) clients.
            }
        }

        private static async Task ProcessClientAsync(TcpClient tcpClient)
        {
            const string NewLine = "\r\n";

            using (NetworkStream networkStream = tcpClient.GetStream())
            {
                // TODO: Use buffer
                byte[] requestBytes = new byte[1000000]; // standart 4096
                int bytesRead = await networkStream.ReadAsync(requestBytes, 0, requestBytes.Length);
                string request = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);
                // convert the read bytes into string
                // UTF8 becouse it is standart encoding for C#

                string responceText = @"<form action='/Action/Login' method='post'> 
<input type=date name='date' />
<input type=text name='username' />
<input type=text password name='password' />
<input type=submit value='Login' />
</form>" + "<h1>" + DateTime.UtcNow + "</h1>";
                // 'post' hides the data in URL, 'get' shows the data in URL

                Thread.Sleep(10000); // wait untill 10 secunds are passed

                string response = "HTTP/1.0 200 OK" + NewLine +
                                   // If instead 200 is 307 and we add "Location: https://google.com" + NewLine + // the page will be redirected to google
                                   "Server: SoftUniServer/1.0" + NewLine +
                                   "Content-Type: text/html" + NewLine +
                                   //"Content-Disposition: attachment; filename=Mitko.html" + NewLine + // Prevent the opening of the page and provide file for download
                                   "Content-Lenght: " + responceText.Length + NewLine +
                                   NewLine +
                                   responceText;

                // only here we use "\r\n" (otherwise Enviroment.NewLine), because if we run the application 
                // under Linux the program will not work correctly
                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);
                //networkStream.Flush(); // Sends the information to the client

                Console.WriteLine(request);
                Console.WriteLine(new string('=', 60));
            }
        }
    }
}
