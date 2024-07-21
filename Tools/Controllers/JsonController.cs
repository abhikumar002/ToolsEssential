using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Tools.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JsonController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var data = new
            {
                Name = "Joshn Dee",
                Age = 30,
                Occupation = "Software Developer"
            };

            return Ok(data);
        }

        [HttpGet("list")]
        public IActionResult GetList()
        {
            var dataList = new List<object>
            {
                new { Name = "Alice", Age = 28, Occupation = "Engineer" },
                new { Name = "Bob", Age = 35, Occupation = "Manager" },
                new { Name = "Charlie", Age = 40, Occupation = "Architect" }
            };

            return Ok(dataList);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Dictionary<string, string> inputData)
        {
            // Process the input data
            var result = new
            {
                Message = "Data received successfully",
                Data = inputData
            };

            return Ok(result);
        }
    }
}