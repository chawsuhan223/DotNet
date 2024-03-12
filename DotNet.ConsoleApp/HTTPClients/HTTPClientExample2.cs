using DotNet.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ConsoleApp.HTTPClients
{
    public class HTTPClientExample2
    {

        public async Task Run()
        {
            //await Read();
            await ReadJSonPlaceHolder();
        }

        private async Task Read()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7248/api/Model");
            if (response.IsSuccessStatusCode)//200 t0 299
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
                List<TestModel> lst = JsonConvert.DeserializeObject<List<TestModel>>(jsonStr)!;
                foreach (TestModel item in lst)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Address);
                    Console.WriteLine(item.Description);
                }
            }
        }

            private async Task ReadJSonPlaceHolder()
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
                if (response.IsSuccessStatusCode)//200 t0 299
                {
                    string jsonStr = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonStr);

                    List<JSonPlaceHolderModel> lst = JsonConvert.DeserializeObject<List<JSonPlaceHolderModel>>(jsonStr)!;
                    foreach (JSonPlaceHolderModel item in lst)
                    {
                        Console.WriteLine(item.userId);
                        Console.WriteLine(item.id);
                        Console.WriteLine(item.title);
                        Console.WriteLine(item.body);
                    }
                }
            }

    }
    }
