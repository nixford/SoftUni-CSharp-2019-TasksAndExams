namespace SIS.Demo
{
    using System.IO;
    using HTTP.Enums;
    using HTTP.Responses.Contracts;
    using SIS.HTTP.Requests.Contracts;
    using WebServer.Results;

    public class HomeController
    {        
        public IHttpResponse Index(IHttpRequest request)
        {
            string content = "<h1>Hello, World!</h1>";

            return new HtmlResult(content, HttpResponseStatusCode.Ok);
        }
    }
}