using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Viandas.Application.DTO.MenuDTO;
using Viandas.Application.Interface.IMenu;

namespace Viandas.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly ICreateMenu _createMenu;

        public MenuController(ICreateMenu createMenu)
        {
            _createMenu = createMenu;
        }

        [HttpPost]
        public IActionResult Create(CreateMenuDTO menu)
        {
            //TODO: recibir el usuario por el JWT
            var creation = _createMenu.CreateMenu(menu, "12345");

            return Ok(creation);
        }
    }
}
