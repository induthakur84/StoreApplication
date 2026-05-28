using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Data.Interfaces;
using Order.DTO.DTO.Request;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Create(UserRequest userRequest)
        {
            var result = await _userService.Create(userRequest);
            if (result == null)
            {
                return BadRequest("Invalid user data.");
            }
            return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAll();
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);
            if (result == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return Ok(result);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, UserRequest userRequest)
        {
            var result = await _userService.Update(id, userRequest);
            if (result == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return Ok(result);
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.Delete(id);
            if (!result)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return Ok($"User with ID {id} deleted successfully.");



        }
    }
}
