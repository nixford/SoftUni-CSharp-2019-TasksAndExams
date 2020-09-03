using SIS.HTTP.Enums;
using SIS.HTTP.HttpElements;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP
{
    public class Route
    {
        public Route(HttpMethodType httpMethod, string path,
            Func<HttpRequest, HttpResponse> action)
        {
            Path = path;
            HttpMethod = httpMethod;
            Action = action;
        }

        public string Path { get; set; }

        public HttpMethodType HttpMethod { get; set; }

        public Func<HttpRequest, HttpResponse> Action { get; set; }
    }
}
