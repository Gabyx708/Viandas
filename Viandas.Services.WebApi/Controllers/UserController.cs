using Microsoft.AspNetCore.Mvc;
using System.Net;
using Viandas.Application.DTO.UserDTO;
using Viandas.Application.Interface.IUser;

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
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public IActionResult CreateNewUser(CreateUserDTO user)
        {
            bool response = _create.CreateUser(user);

            if (response)
            {
                return Created();
            }

            return BadRequest("failed to create user");
        }
    }
}
