using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());

            string input = string.Empty;

            Dictionary<string, int> usernameSent = new Dictionary<string, int>();
            Dictionary<string, int> usernameReceived = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] inputLine = input.Split('=').ToArray();

                if (inputLine[0] == "Add")
                {
                    string username = inputLine[1];
                    int sentCount = int.Parse(inputLine[2]);
                    int receivedCount = int.Parse(inputLine[3]);
                    if (!usernameSent.ContainsKey(username) && !usernameReceived.ContainsKey(username))
                    {                        
                        usernameSent.Add(username, sentCount);
                        usernameReceived.Add(username, receivedCount);
                    }                    
                }
                else if (inputLine[0] == "Message")
                {
                    string sender = inputLine[1];
                    string receiver = inputLine[2];
                    if ((usernameSent.ContainsKey(sender) && usernameSent.ContainsKey(receiver)) &&
                        (usernameReceived.ContainsKey(sender) && usernameReceived.ContainsKey(receiver)))
                    {
                        usernameSent[sender] += 1;
                        if (usernameSent[sender] + usernameReceived[sender] >= capacity)
                        {
                            usernameSent.Remove(sender);
                            usernameReceived.Remove(sender);
                            Console.WriteLine($"{sender} reached the capacity!");
                        }

                        usernameReceived[receiver] += 1;
                        if (usernameReceived[receiver] + usernameSent[receiver] >= capacity)
                        {
                            usernameReceived.Remove(receiver);
                            usernameSent.Remove(receiver);
                            Console.WriteLine($"{receiver} reached the capacity!");
                        }                                    
                    }
                }
                else if (inputLine[0] == "Empty")
                {
                    string username1 = inputLine[1];
                    if (username1 != "All")
                    {
                        if (usernameReceived.ContainsKey(username1) && usernameSent.ContainsKey(username1))
                        {
                            usernameReceived.Remove(username1);
                            usernameSent.Remove(username1);
                        }                       
                    }
                    else
                    {
                        usernameReceived.Clear();
                        usernameSent.Clear();
                    }
                }               
            }
            if (usernameReceived != null && usernameSent != null)
            {
                Console.WriteLine($"Users count: {usernameReceived.Keys.Count}");
                foreach (var kvp in usernameReceived.OrderByDescending(v => v.Value).ThenBy(k => k.Key))
                {
                    Console.WriteLine($"{kvp.Key} - {kvp.Value + usernameSent[kvp.Key]}");
                }
            }   
        }
    }
}
