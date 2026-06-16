using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TableMapping.Entity.Request;
using TableMapping.Entity.Response;
using TableMapping.Interface;

namespace TableMapping.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController(IUserBl muserBl) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Create(UserRequest request)
        {
            try
            {
                UserResponse result = await muserBl.AddUser(request);
                return StatusCode(201, result);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserId(long id)
        {
            try
            {
                UserResponse result = await muserBl.GetUserId(id);

                return Ok(result);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserRequest request,long id )
        {
            try
            {
                UserResponse result = await muserBl.UpdateUser(request,id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            try
            {
                UserResponse result = await muserBl.DeleteUser(id);

                return Ok("Deleted successfully");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
        
    }
}
