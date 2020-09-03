﻿using SIS.HTTP;
using SIS.HTTP.Enums;
using SIS.HTTP.HttpElements;
using SIS.HTTP.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp

{
    class Program
    {
        static async Task Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();

            var routeTable = new List<Route>();
            routeTable.Add(new Route(HttpMethodType.Get, "/", Index));
            routeTable.Add(new Route(HttpMethodType.Post, "/Tweets/Create", CreateTweet));           
            routeTable.Add(new Route(HttpMethodType.Get, "/favicon.ico", FavIcon));

            HttpServer httpServer = new HttpServer(80, routeTable);

            await httpServer.StartAsync();
        }

        private static HttpResponse FavIcon(HttpRequest request)
        {
            var byteContent = File.ReadAllBytes("wwwroot/favicon.ico");
            return new FileResponse(byteContent, "image/x-icon");
        }        

        public static HttpResponse Index(HttpRequest request)
        {
            var username = request.SessionData.ContainsKey("Username") ? request.SessionData["Username"] : "Anonymos";
            return new HtmlResponse("<form action='/Tweets/Create' method='post'><input name='creator' /><br /><textarea name='tweetName'></textarea><br /><input type='submit' /></form>");
        } 
        
        public static HttpResponse CreateTweet(HttpRequest request)
        {
            var db = new ApplicationDbContext();
            db.Tweets.Add(new Tweet 
            { 
                CreatedOn = DateTime.UtcNow,
                Creator = request.FormData["creator"],
                Content = request.FormData["tweetName"],
            });
            db.SaveChanges();

            return new HtmlResponse("Thank you for your tweet!!!");
        }
    }
}
