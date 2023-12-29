    using CharityClinic.Data.ModelApi;
using Microsoft.AspNetCore.Mvc;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CharityClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileProcessController : ControllerBase
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        public FileProcessController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _environment = environment;
        }
        // GET: api/<FileProcessController>
        [HttpPost("/FileProcess")]
        public async Task<IActionResult> OnPostProcessFileAsync([FromForm]RequestFile requestFile)
        {
            try
            {
                var fileName = Guid.NewGuid().ToString() + ".jpg";
                var file = Path.Combine(_environment.ContentRootPath, "wwwroot", requestFile.path, fileName);
                if (!Directory.Exists(Path.Combine(_environment.ContentRootPath, "wwwroot", requestFile.path)))
                {
                    Directory.CreateDirectory(Path.Combine(_environment.ContentRootPath, "wwwroot", requestFile.path));
                }
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await requestFile.file.CopyToAsync(fileStream);
                }
                return Ok(Path.Combine(requestFile.path, fileName));
            }
            catch (Exception e)
            {

                throw;
            }
        }

        // GET api/<FileProcessController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FileProcessController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FileProcessController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FileProcessController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
