using Azure.Core;
using ManyToMany.Entity.Model;
using ManyToMany.Entity.Request;
using ManyToMany.Entity.Response;
using ManyToMany.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManyToMany.Controllers
{
    [Route("api/v1/student")]
    [ApiController]
  
public class StudentController(IStudentBl studentBl) : ControllerBase
    {
       
            [HttpPost]
            public async Task<IActionResult> AddStudent(StudentRequest request)
            {
            try
            {
                StudentResponse result = await studentBl.AddStudent(request);
                return StatusCode(201, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

            [HttpGet]
            public async Task<IActionResult> GetUserAll()
            {
            try
            {
                List<StudentResponse> result = await studentBl.GetUserAll();
                return Ok(result);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
            }
        [HttpPut]
        public async Task<IActionResult> UpdateStudent(StudentRequest request,long id)
        {
            try
            {
                StudentResponse result = await studentBl.UpdateStudent(request, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(long id)
        {
            try
            {
                StudentResponse result = await studentBl.DeleteStudent(id);
                return Ok("Deleted successfully");
            }
            catch (Exception ex) {  
                return BadRequest(ex.Message);}
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(long id)
        {
            try
            {
                StudentResponse result = await studentBl.GetStudentById(id);
                return Ok(result);
            }
            catch (Exception ex) {  return BadRequest(ex.Message);}
            }

        }

    }
    

