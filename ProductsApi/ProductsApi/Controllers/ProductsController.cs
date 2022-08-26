using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Entities;
using ProductsApi.Models;
using ProductsApi.Services;
using System.Linq;

namespace Products.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductsRepository repository;
        public ProductsController(IProductsRepository _repository)
        {
            repository = _repository;
        }

        [HttpGet]
        public IActionResult GetProducts([FromQuery] int? categoryID)
        {
            var result = repository.GetProducts(categoryID);

            var productDtos = result.Results.Select(x => new ProductDto { ID = x.ID, Name = x.Name, Price = x.Price, Quantity = x.Quantity, ImgURL = x.ImgURL, CategoryID = x.CategoryID }).ToList();

            var response = new ApiResponse()
            {
                Success = result.Success,
                Results = productDtos
            };

            return Ok(response);
        }

        [HttpGet("{productId}", Name = "GetProductId")]
        public IActionResult GetProductById([FromRoute] int productId)
        {
            var response = new ApiResponse();

            var result = repository.GetProductById(productId);

            if (!result.Success)
            {
                response.Success = result.Success;
                response.Messages = result.Messages;

                return NotFound(response);
            }

            var productDto = new ProductDto { ID = result.Result.ID, Name = result.Result.Name, Price = result.Result.Price, Quantity = result.Result.Quantity, ImgURL = result.Result.ImgURL, CategoryID = result.Result.CategoryID };

            response.Success = result.Success;
            response.Result = productDto;

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductForCreation productForCreation)
        {
            var response = new ApiResponse();

            var productEntity = new Product { Name = productForCreation.Name, Price = (int)productForCreation.Price, Quantity = (int)productForCreation.Quantity, ImgURL = productForCreation.ImgURL, CategoryID = (int)productForCreation.CategoryID };

            var result = repository.CreateProduct(productEntity);

            if (!result.Success)
            {
                response.Success = result.Success;
                response.Messages = result.Messages;

                return NotFound(response);
            }

            var productDto = new ProductDto { ID = result.Result.ID, Name = result.Result.Name, Price = result.Result.Price, Quantity = result.Result.Quantity, ImgURL = result.Result.ImgURL, CategoryID = result.Result.CategoryID };

            response.Success = result.Success;
            response.Result = productDto;

            return CreatedAtRoute("GetProductId", new { productId = productDto.ID }, response);
        }

        [HttpPut]
        [Route("{productId}")]
        public IActionResult UpdateProduct([FromRoute] int productId, [FromBody] ProductForUpdate productForUpdate)
        {
            var response = new ApiResponse();

            var productEntity = new Product { ID = productId, Name = productForUpdate.Name, Price = productForUpdate.Price, Quantity = productForUpdate.Quantity, ImgURL = productForUpdate.ImgURL, CategoryID = productForUpdate.CategoryID };

            var result = repository.UpdateProduct(productEntity);

            if (!result.Success)
            {
                response.Success = result.Success;
                response.Messages = result.Messages;

                return NotFound(response);
            }

            var productDto = new ProductDto { ID = result.Result.ID, Name = result.Result.Name, Price = result.Result.Price, Quantity = result.Result.Quantity, ImgURL = result.Result.ImgURL, CategoryID = result.Result.CategoryID };

            response.Success = result.Success;
            response.Result = productDto;

            return Ok(response);
        }
    }
}
