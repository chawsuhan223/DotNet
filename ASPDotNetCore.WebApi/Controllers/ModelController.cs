using ASPDotNetCore.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ASPDotNetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        //Read => Get / Create => post / Update => Put / Delete => Delete / Edit => Get

        private readonly AppDbContent _db;
        public ModelController()
        {
            _db = new AppDbContent();
        }
        [HttpGet]
        public IActionResult  GetTest()//IActionResult give return JSON
        {
            List<Model> lst = _db.TestModel.OrderByDescending(x => x.Id).ToList();
            return Ok(lst);
        }
        [HttpGet("{id}")]
        public IActionResult GetTestget(int id)//IActionResult give return JSON
        {
            Model? item = _db.TestModel.FirstOrDefault(item => item.Id == id);
            if (item is null)
            {
                return NotFound("No Data Found");
            };
            return Ok(item);
        }
        [HttpPost]
        public IActionResult CreateTest(Model model)
        {
            _db.TestModel.Add(model);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Creating Successful" : "Creating Failed";
            return Ok(message);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTest(int id,Model model)
        {
            Model? item = _db.TestModel.FirstOrDefault(item =>item.Id==id);
            if (item is null)
            {
                return NotFound("No Data Found");
            };
            item.Name = model.Name;
            item.Address = model.Address;
            item.Description = model.Description;

            int result = _db.SaveChanges();//Execute
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTest(int id)
        {
            
            Model? item = _db.TestModel.FirstOrDefault(item => item.Id == id);
            if (item is null)
            {
                return NotFound("No Data Found");
            };
            _db.TestModel.Remove(item);
            int result = _db.SaveChanges();//Execute
            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            return Ok(message);
        }
    }
}
