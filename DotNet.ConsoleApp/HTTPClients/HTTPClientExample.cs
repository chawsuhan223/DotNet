using DotNet.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ConsoleApp.HTTPClients
{
    public class HTTPClientExample
    {
        public async Task Run()
        {
            //await Read();
            await Edit(1);
            await Edit(10);
        }
        private async Task Read()//Read
        {
            HttpClient client = new HttpClient();//get data
            HttpResponseMessage response=await client.GetAsync("https://localhost:7248/api/Model");//endpoint
            if(response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();//get as string
                List<TestModel> lst = JsonConvert.DeserializeObject<List<TestModel>>(json);//json to C#
                foreach (TestModel item in lst)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Address);
                    Console.WriteLine(item.Description);
                }
     
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }//Read
        private async Task Edit(int id)//Edit
        {
            string url = $"https://localhost:7248/api/Model/{id}";
            HttpClient client = new HttpClient();//get data
            HttpResponseMessage response = await client.GetAsync(url);//endpoint
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();//get as string
                TestModel item = JsonConvert.DeserializeObject<TestModel>(json)!;//json to C#

                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Address);
                    Console.WriteLine(item.Description);
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }//Edit
    }
}
