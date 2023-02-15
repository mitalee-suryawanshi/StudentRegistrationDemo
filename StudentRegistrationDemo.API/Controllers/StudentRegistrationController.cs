using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Studentregistration.Core.Domain.RequestModel;
using StudentRegistration.Core.Contract;
using StudentRegistration.Infra.Domain;

namespace StudentRegistrationDemo.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class StudentRegistrationController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly StudentContext _studentContext;

        public StudentRegistrationController(IStudentService studentService, StudentContext studentContext)
        {
            _studentService = studentService;
            _studentContext=studentContext;
        }

        [HttpGet]
        [Route("GetAllStudentsData")]
        public async Task<IActionResult> GetStudents(string? searchTerm=null,int page=1,int pageSixe=25)
        {
            var result = await _studentService.GetStudentAsync(searchTerm,page,pageSixe);
            return Ok(result);
        }

        [HttpPost]
        [Route("AddStudentsData")]
        public async Task<IActionResult> PostStudents([FromForm]StudentRequestModel student)
        {
            await _studentService.AddStudentAsync(student);
            return Created("students", null);
        }

        [HttpPut]
        [Route("UpdateStudentsData")]
        public async Task<IActionResult>PutStudents([FromForm]StudentRequestModel student,long studentId)
        {
            await _studentService.UpadateStudentAsync(student,studentId);
            return Ok(student);
        }

        [HttpDelete]
        [Route("DeleteStudentsData")]
        public async Task<IActionResult>DeleteStudents(long id)
        {
            await _studentService.DeleteStudentAsync(id);
            return NoContent();
        }
    }
}