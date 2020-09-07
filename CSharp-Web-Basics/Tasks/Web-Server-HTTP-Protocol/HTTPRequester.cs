using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HTTPRequester
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string NewLine = "\r\n";

            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 1234); // Default port is 80
            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();                

                using (NetworkStream networkStream = tcpClient.GetStream())
                {

                    // TODO: Use buffer
                    byte[] requestBytes = new byte[1000000]; // standart 4096

                    int bytesRead = networkStream.Read(requestBytes, 0, requestBytes.Length);

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
                    networkStream.Write(responseBytes, 0, responseBytes.Length);

                    //networkStream.Flush(); // Sends the information to the client

                    Console.WriteLine(request);
                    Console.WriteLine(new string('=', 60));
                }
            }
        }

        public static async Task HttpRequesForm()
        {
            const string NewLine = "\r\n";

            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 1234); // Default port is 80
            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();

                await using (NetworkStream networkStream = tcpClient.GetStream())
                {

                    // TODO: Use buffer
                    byte[] requestBytes = new byte[1000000]; // standart 4096

                    int bytesRead = networkStream.Read(requestBytes, 0, requestBytes.Length);

                    string request = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);
                    // convert the read bytes into string
                    // UTF8 becouse it is standart encoding for C#

                    string responseText = "<h1>Hello Header</h1>";

                    string response = "HTTP/1.0 200 OK" + NewLine + 
                                       // If instead 200 is 307 and we add "Location: https://google.com" + NewLine + // the page will be redirected to google
                                       "Server: SoftUniServer/1.0" + NewLine +
                                       "Content-Type: text/html" + NewLine +
                                       //"Content-Disposition: attachment; filename=Mitko.html" + NewLine + // Prevent the opening of the page and provide file for download
                                       "Content-Lenght: " + responseText.Length + NewLine +
                                       NewLine +
                                       responseText;

                    // only here we use "\r\n" (otherwise Enviroment.NewLine), because if we run the application 
                    // under Linux the program will not work correctly
                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    networkStream.Write(responseBytes, 0, responseBytes.Length);

                    //networkStream.Flush(); // Sends the information to the client

                    Console.WriteLine(request);
                    Console.WriteLine(new string('=', 60));
                }
            }
        }        
        

        public static async Task HttpRequest()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://softuni.bg/");
            string result = await response.Content.ReadAsStringAsync();
            //client.GetAsync("https://softuni.bg/").GetAwaiter().GetResult(); //- when there is no async Task in the method
            Console.WriteLine(result);
            File.WriteAllText("../../../result.html", result);
        }
    }
}
