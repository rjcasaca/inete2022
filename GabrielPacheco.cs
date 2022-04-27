using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace GetPost_Exemple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var cliente = new HttpClient())
            {
                var endpoint = new Uri("https://jsonplaceholder.typicode.com/posts");

                #region Method Get
                var result1 = cliente.GetAsync(endpoint).Result;
                var json = result1.Content.ReadAsStringAsync().Result;
                #endregion
Lucas
                #region Method Post
                var newPost = new Post()
                {
                    Title = "Test Post",
                    Body = "Hello world!",
                    UserId = 44
                };
                var newPOstJson = JsonConvert.SerializeObject(newPost);
                var payload = new StringContent(newPOstJson, Encoding.UTF8, "application/json");
                var result2 = cliente.PostAsync(endpoint, payload).Result.Content.ReadAsStringAsync().Result;
                #endregion
            }
        }
    }

    public class Post
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
    }
}
