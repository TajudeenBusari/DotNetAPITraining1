using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] { "John", "Buu", "Tayo", "Segun" };
            return Ok(studentNames);
        }
    }
}
