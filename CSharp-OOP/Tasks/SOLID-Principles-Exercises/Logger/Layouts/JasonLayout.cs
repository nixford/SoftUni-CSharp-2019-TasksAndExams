using P01Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01Logger.Layouts
{
    public class JasonLayout : ILayout
    {
        public string Format => @"{{
  ""log"": {{
    ""date"": ""{0}"",
    ""level"": ""{1}"",
    ""message"": ""{2}""
  }}
}}";

    }
}
