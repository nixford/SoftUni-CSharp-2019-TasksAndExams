using SIS.HTTP.Enums;
using SIS.HTTP.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace SIS.HTTP.HttpElements
{
    public class HttpRequest
    {
        public HttpRequest(string httpRequestAsString)
         {
            this.Headers = new List<Header>();
            // StringReader reader = new StringReader(httpRequestAsString);
            // reader.ReadLine();

            var lines = httpRequestAsString.Split(
                new string[] { HttpConstants.NewLine },
                StringSplitOptions.None);
            var httpInfoHeader = lines[0];
            var infoHttpInfoHeaderParts = httpInfoHeader.Split(' ');
            if (infoHttpInfoHeaderParts.Length != 3)
            {
                throw new HttpServerException("Invalid HTTP header line!");
            }

            var httpMethod = infoHttpInfoHeaderParts[0];

            //Enum.TryParse(httpMethod, out HttpMethodType type);
            //this.Method = type;

            this.Method = httpMethod switch
            {
                "GET" => HttpMethodType.Get,
                "POST" => HttpMethodType.Post,
                "PUT" => HttpMethodType.Put,
                "DELETE" => HttpMethodType.Delete,
                _ => HttpMethodType.Unknown,
            };

            this.Path = infoHttpInfoHeaderParts[1];

            var httpVersion = infoHttpInfoHeaderParts[2];
            //Enum.TryParse(httpVersion, out HttpVersionType versionType);
            //this.Version = versionType;

            this.Version = httpVersion switch
            {
                "HTTP/1.0" => HttpVersionType.Http10,
                "HTTP/1.1" => HttpVersionType.Http11,
                "HTTP/2.0" => HttpVersionType.Http20,
                _ => HttpVersionType.Http10,
            };

            StringBuilder bodyBuilder = new StringBuilder();
            bool isInHeader = true;
            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    isInHeader = false;
                    continue;
                }

                if (isInHeader)
                {
                    var headerParts = line.Split
                        (new string[] { ": " }, 
                        2, 
                        StringSplitOptions.None);

                    if (headerParts.Length != 2)
                    {
                        throw new HttpServerException
                            ($"Invalid header: {line}");
                    }

                    var header = new Header(headerParts[0], headerParts[1]);

                    this.Headers.Add(header);
                }
                else
                {
                    bodyBuilder.AppendLine(line);
                }
            }
        }

        public HttpMethodType Method { get; set; }
        // There is ready calss of HttpMethod

        public string Path { get; set; }

        public HttpVersionType Version { get; set; }

        public IList<Header> Headers { get; set; }

        public string Body { get; set; }
    }
}
