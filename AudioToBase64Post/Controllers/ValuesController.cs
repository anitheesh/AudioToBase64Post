// ValuesController
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AudioToBase64Post.Model;
using AudioToBase64Post.Repository;

namespace AudioToBase64Post.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Class model)
        {

            try
            {
                Exception exception = new Exception();
                audioRepo audio = new audioRepo(_configuration);
                string result = audio.PostAudio(model);
                if(result == "Success")
                {
                    return Ok("Success");
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, new { error = exception.Message });

                }


            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { error = e.Message });
            }
        }
    }
}