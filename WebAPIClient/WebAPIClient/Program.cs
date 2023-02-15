using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebAPIClient
{
    class Joke
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("setup")]
        public string SetUp { get; set; }

        [JsonProperty("punchline")]
        public string Punchline { get; set; }
    }
    class Program 
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }

        private static async Task ProcessRepositories()
        {
            var apiUrl = "https://official-joke-api.appspot.com/random_joke";
            while (true)
            {
                try
                {
                    Console.WriteLine("Do you want to listen to a joke? (y/n)");
                    var ans = Console.ReadLine();
                    if (string.IsNullOrEmpty(ans) || ans.ToLower() == "n")
                    {
                        break;
                    }
                    else if (ans.ToLower() == "y")
                    {
                        var result = await client.GetAsync(apiUrl);
                        var resultRead = await result.Content.ReadAsStringAsync();

                        var joke = JsonConvert.DeserializeObject<Joke>(resultRead);

                        Console.WriteLine("---");
                        Console.WriteLine("Joke #" + joke.Id);
                        Console.WriteLine("Joke Type: " + joke.Type);
                        Console.WriteLine("Joke: " + joke.SetUp);
                        Console.WriteLine("Punchline: " + joke.Punchline);
                        Console.WriteLine("---");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error. Input can't be read!");
                }

            }

        }
    }
}