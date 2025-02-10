using Microsoft.AspNetCore.Mvc;
using Viandas.Application.DTO.DishDTO;
using Viandas.Application.Interface.IDish;
using Viandas.Transversal.Common;

namespace Viandas.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly ICreateDish _createDish;
        private readonly IUpdateDishesPrice _updatePrice;
        private readonly IQueryDish _queryDish;

        public DishController(ICreateDish createDish, IQueryDish queryDish, IUpdateDishesPrice updatePrice)
        {
            _createDish = createDish;
            _queryDish = queryDish;
            _updatePrice = updatePrice;
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetDishDTO), 201)]
        public IActionResult CreateNewDish(CreateDishDTO dish)
        {
            GetDishDTO newDish;

            try
            {
                newDish = _createDish.CreateDish(dish);

            }
            catch (Exception ex)
            {
                return new JsonResult(new ApiResponse(ex.Message, 500))
                { StatusCode = 500 };
            }

            return new ObjectResult(newDish) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetDishesDTO), 200)]
        public IActionResult GetDishes(string? description)
        {
            GetDishesDTO dishes;

            if (string.IsNullOrEmpty(description))
            {
                dishes = _queryDish.GetDishes();
            }
            else
            {
                dishes = _queryDish.GetDishByDescription(description);
            }

            return Ok(dishes);
        }

        [HttpPatch("update-prices")]
        public IActionResult UpdatePrices(decimal price)
        {
            bool isUpdated = _updatePrice.UpdatePrices(price);

            if(isUpdated)
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
