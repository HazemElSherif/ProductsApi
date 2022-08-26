using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;
using ProductsApi.Services;
using System.Linq;

namespace Products.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoriesRepository repository;
        public CategoriesController(ICategoriesRepository _repository)
        {
            repository = _repository;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var result = repository.GetCategories();

            var categories = result.Results.Select(x => new CategoryDto { ID = x.ID, Name = x.Name });

            var response = new ApiResponse()
            {
                Success = result.Success,
                Results = categories
            };

            return Ok(response);
        }
    }
}
