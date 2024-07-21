using Microsoft.AspNetCore.Mvc;
using Tools.Services;
using Tools.Models;
using Tools.Interfaces;
using System.Collections.Generic;


namespace Tools.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JsonValidationController : ControllerBase
    {
        private readonly IJsonValidationService _validationService; //Declare

        public JsonValidationController(IJsonValidationService validationService) //Constroller for intialization
        {
            _validationService = validationService;
        }

        [HttpPost]
        [Route("validate")]
        public IActionResult ValidateJson([FromBody] JsonValidationRequest request)
        {
            var isValid = _validationService.ValidateJson(request.JsonString, request.SchemaString, out List<string> errors);

            if (isValid)
            {
                return Ok(new { Message = "JSON is valid" });
            }
            else
            {
                return BadRequest(new { Errors = errors });
            }
        }


    }
}