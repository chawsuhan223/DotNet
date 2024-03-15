using DotNetTestApi.WebAPi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace DotNetTestApi.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BirdController : ControllerBase
    {
        //private readonly string _url = "https://burma-project-ideas.vercel.app/birds";                     }
        [HttpGet]
        public async Task<IActionResult> Read()
        {
            HttpClient client = new HttpClient();
        var response = await client.GetAsync("https://burma-project-ideas.vercel.app/birds");
            if (response.IsSuccessStatusCode)
            {
                string JSON = await response.Content.ReadAsStringAsync();
                List<BirdDataModel> birds = JsonConvert.DeserializeObject<List<BirdDataModel>>(JSON);
                //return Ok(JSON);
                List<BirdViewModel> lst = birds.Select(bird => new BirdViewModel
                {
                    BirdId = bird.Id,
                    BirdName = bird.BirdMyanmarName,
                    PhotoURL = $"https://burma-project-ideas.vercel.app/{bird.ImagePath}",
                    Des = bird.Description,
                }).ToList();

                return Ok(lst);
            }
            else
            {
                return BadRequest();
            }
        }
        // var lst = birds.Select(bird => new BirdViewModel
        // {
        //     BirdId = bird.Id,
        //     BirdName = bird.BirdMyanmarName,
        //     PhotoURL = bird.ImagePath,
        //     Des = bird.Description,
        // }
        //);




        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(int id)//IActionResult give return JSON
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://burma-project-ideas.vercel.app/birds/{id}");
            if (response.IsSuccessStatusCode)
            {
                string JSON = await response.Content.ReadAsStringAsync();
                BirdDataModel bird = JsonConvert.DeserializeObject<BirdDataModel>(JSON);
               var lst = new BirdViewModel
                {
                    BirdId = bird.Id,
                    BirdName = bird.BirdMyanmarName,
                    PhotoURL = $"https://burma-project-ideas.vercel.app/{bird.ImagePath}",
                    Des = bird.Description,
                };

                return Ok(lst);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
