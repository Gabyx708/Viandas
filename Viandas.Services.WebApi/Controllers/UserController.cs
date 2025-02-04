using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Viandas.Application.DTO.UserDTO;
using Viandas.Application.Interface;

namespace Viandas.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICreateUser _create;

        public UserController(ICreateUser create)
        {
            _create = create;
        }

        [HttpPost]
        public IActionResult CreateNewUser(CreateUserDTO user)
        {
            bool response = _create.CreateUser(user);
            
            if(response)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
