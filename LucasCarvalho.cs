using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace conconsole
{
     class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("http://jsonplaceholder.typicode.com/posts");
                //var result = client.GetAsync(endpoint).Result;
                //var json = result.Content.ReadAsStringAsync().Result;
                var newPost = new post()
                {
                    Title = "Test Post",
                    Body = "Hello world",
                    UserId = 44
                };

                var NewPostJson = JsonConvert.SerializeObject(newPost);
                var payload = new StringContent (NewPostJson,Encoding.UTF8,"application/json");
               var result = client.PostAsync(endpoint, payload).Result.Content.ReadAsStringAsync().Result;
            }
        }
    }
}