// ValuesController
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AudioToBase64Post.Model;

namespace AudioToBase64Post.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Class model)
        {

            try
            {
                

                    // Construct the response message including EmployeeID and Email
                    var responseMessage = new
                    {
                        model.File,
                        model.EmployeeID,
                        model.Email
                    };
                    return Ok(responseMessage);
                
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { error = e.Message });
            }
        }
    }
}
