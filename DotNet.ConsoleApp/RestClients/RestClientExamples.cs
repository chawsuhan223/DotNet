using DotNet.ConsoleApp.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ConsoleApp.RestClients
{
    public class RestClientExamples
    {
        private readonly string url = "https://localhost:7248/api/Model";//7248
        public async Task Run()
        {
            await Read();
            //await Edit(1);
            // await Edit(10);
            //await Create("CSH", "Yamethin", "Snack");
            //await Update(1004, "KHL", "Mandalay", "Bread");
            //await Delete(1004);
        }

        private async Task Read()//Read
        {
            RestRequest request = new RestRequest(url,Method.Get);
            RestClient client = new RestClient(); //Get data
            //client.GetAsync//for Method Get
             RestResponse response =await client.ExecuteAsync(request);//for all Method
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content!;//get as string
                List<TestModel> lst = JsonConvert.DeserializeObject<List<TestModel>>(json)!;//json to C#
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
                Console.WriteLine( response.Content!);
            }
        }//Read

        private async Task Edit(int id)//Edit
        {
            string url1 = $"{url}/{id}";
            RestRequest request = new RestRequest(url1, Method.Get);
            RestClient client = new RestClient(); //Get data
            RestResponse response = await client.ExecuteAsync(request);//for all Method
            if (response.IsSuccessStatusCode)
            {
                string json =response.Content!;//get as string
                TestModel item = JsonConvert.DeserializeObject<TestModel>(json)!;//json to C#

                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Address);
                Console.WriteLine(item.Description);
            }
            else
            {
                Console.WriteLine( response.Content);
            }
        }//Edit

        private async Task Create(string Name, string Address, string Description)//Create
        {
            TestModel testModel = new TestModel()
            {
                Name = Name,
                Address = Address,
                Description = Description,
            };
            RestRequest request = new RestRequest(url, Method.Post);
            request.AddJsonBody(testModel);
            RestClient client = new RestClient(); //Get data
            RestResponse response = await client.ExecuteAsync(request);//for all Method
            if (response.IsSuccessStatusCode)
            {
                //string json = response.Content!;//get as string
                Console.WriteLine( response.Content);
            }
            else
            {
                Console.WriteLine(response.Content);
            }
        }//Create

        private async Task Update(int id, string Name, string Address, string Description)//Update
        {
            TestModel testModel = new TestModel()
            {
                Id = id,
                Name = Name,
                Address = Address,
                Description = Description,
            };
           
            string url1 = $"{url}/{id}";
            RestRequest request = new RestRequest(url1, Method.Put);
            RestClient client = new RestClient(); //Get data
            RestResponse response = await client.ExecuteAsync(request);//for all Method
            if (response.IsSuccessStatusCode)
            {
                //string json = response.Content!;//get as string
                Console.WriteLine(response.Content);
            }
            else
            {
                Console.WriteLine(response.Content);
            }
        }//Update

        private async Task Delete(int id)//Delete
        {
            string url1 = $"{url}/{id}";
            RestRequest request = new RestRequest(url1, Method.Delete);
            RestClient client = new RestClient(); //Get data
            RestResponse response = await client.ExecuteAsync(request);//for all Method
            if (response.IsSuccessStatusCode)
            {
                //string json = response.Content!;//get as string
                Console.WriteLine(response.Content);
            }
            else
            {
                Console.WriteLine(response.Content);
            }
        }//Delete
    }
}

