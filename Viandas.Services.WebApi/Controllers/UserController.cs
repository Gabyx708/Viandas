using Microsoft.AspNetCore.Mvc;
using System.Net;
using Viandas.Application.DTO.UserDTO;
using Viandas.Application.Interface.IUser;
using Viandas.Transversal.Common;

namespace Viandas.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICreateUser _create;
        private readonly IDeleteUser _delete;
        private readonly IQueryUser _query;

        public UserController(ICreateUser create, IQueryUser query, IDeleteUser delete)
        {
            _create = create;
            _query = query;
            _delete = delete;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetUserDTO), (int)HttpStatusCode.OK)]
        public IActionResult GetUserById(string id)
        {
            var user = _query.GetUser(id);

            return Ok(user);
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetUsersDTO), (int)HttpStatusCode.OK)]
        public IActionResult GetActivatedUsers()
        {
            var users = _query.GetUsers();
            return Ok(users);
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


        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            var isDelete = _delete.DisableUser(id);

            if(isDelete)
            {
                return new JsonResult(new ApiResponse("user successfully deleted!", 200))
                                      { StatusCode = 200};
            }

            return NotFound("userId not found");
        }
    }
}
