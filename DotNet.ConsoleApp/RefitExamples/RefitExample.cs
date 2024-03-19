using DotNet.ConsoleApp.Models;
using Microsoft.Identity.Client;
using Refit;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ConsoleApp.RefitExamples
{
    public class RefitExample
    {
        //private readonly string apiUrl ="https://localhost:7114";
        private readonly IBlogAPI refitApi = RestService.For<IBlogAPI>("https://localhost:7248");  //https://localhost:7114 https://localhost:7248

        public async Task Run()
        {
            //await Read();
            //await Edit(1);
            //await Edit(0);
            //await Create("Test","Test","Test");
            //await Update(1004, "Test2", "Test2", "Test2");
            //await Update(1005, "Test2", "Test2", "Test2");
            await Delete(1005);
        }

        private async Task Read()
        {
            //var RefitAPI = RestService.For<IBlogAPI>(apiUrl);
            //var lst = await refitApi.GetBlog();
            //foreach (TestModel item in lst)

            var gitHubApi = RestService.For<IBlogAPI>("https://localhost:7248");
            var octocat = await gitHubApi.GetBlog();

            foreach (TestModel item in octocat)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Address);
                Console.WriteLine(item.Description);
            }
        }

        private async Task Edit(int id)
        {
            try
            {
                //var item = await refitApi.GetBlogs(1);
                var item = await refitApi.GetBlogs(id);

                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Address);
                Console.WriteLine(item.Description);
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());//404 Not Found
            }
        }

        private async Task Create(string Name, string Address, string Description)//Create
        {
            Model model = new Model()
            {
                Name = Name,
                Address = Address,
                Description = Description,
            };
            try
            {
                string message= await refitApi.CreateBlog(model);
                Console.WriteLine(message);
  
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());//404 Not Found
            }

        }//Create

        private async Task Update(int id, string Name, string Address, string Description)//Update
        {
            Model model = new Model()
            {
                Id = id,
                Name = Name,
                Address = Address,
                Description = Description,
            };
            try
            {
                string message = await refitApi.UpdateBlog(id,model);
                Console.WriteLine(message);

            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());//404 Not Found
            }


        }//Update

        private async Task Delete(int id)//Delete
        {
            try
            {
                string message = await refitApi.DeleteBlog(id);
                Console.WriteLine(message);

            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());//404 Not Found
            }

        }//Delete
    }
}
