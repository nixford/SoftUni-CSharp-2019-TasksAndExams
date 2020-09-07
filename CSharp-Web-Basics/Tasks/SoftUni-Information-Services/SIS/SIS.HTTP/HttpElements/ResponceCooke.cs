﻿using SIS.HTTP.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.HttpElements
{
    public class ResponceCooke : Cookie
    {
        public ResponceCooke(string name, string value)
            : base(name, value)
        {
            this.Path = "/";
            this.SameSite = SameSiteType.None;
            this.Expires = DateTime.UtcNow.AddDays(30);
        }
        public string Domain { get; set; }

        public string Path { get; set; }

        public DateTime? Expires { get; set; }

        public long? MaxAge { get; set; }

        public bool Secure { get; set; }

        public bool HttpOnly { get; set; }

        public SameSiteType SameSite { get; set; }

        public override string ToString()
        {
            StringBuilder cookieBuilder = new StringBuilder();
            cookieBuilder.Append($"{this.Name}={this.Value}");

            if (this.MaxAge.HasValue)
            {
                cookieBuilder.Append($"; Max-Age=" + this.MaxAge.Value.ToString());
            }
            else if (this.Expires.HasValue)
            {
                cookieBuilder.Append($"; Expires=" + this.Expires.Value.ToString("R"));
            }

            if (!string.IsNullOrWhiteSpace(this.Domain))
            {
                cookieBuilder.Append($"; Domain=" + this.Domain);
            }

            if (!string.IsNullOrWhiteSpace(this.Path))
            {
                cookieBuilder.Append($"; Path=" + this.Path);
            }

            if (this.Secure == true)
            {
                cookieBuilder.Append("; Secure");
            }

            if (this.HttpOnly)
            {
                cookieBuilder.Append("; HttpOnly");
            }

            cookieBuilder.Append("; SameSite=" + this.SameSite);

            return cookieBuilder.ToString();
        }
    }
}
