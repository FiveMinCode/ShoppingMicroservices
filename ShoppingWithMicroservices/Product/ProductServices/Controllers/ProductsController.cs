using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductServices.Dto;
using ProductServices.Entities;
using ProductServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProductServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductsController> _logger;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository repository, ILogger<ProductsController> logger, 
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IList<ProductDto>>> GetProducts()
        {
            var products = await _repository.GetProducts();
            return Ok(_mapper.Map<IList<ProductDto>>(products));
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<ProductDto>> GetProductById(string id)
        {
            var product = await _repository.GetProduct(id);

            if (product == null)
            {
                _logger.LogError($"Product with id: {id}, not found.");
                return NotFound();
            }

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [Route("[action]/{category}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductByCategory(string category)
        {
            var products = await _repository.GetProductByCategory(category);
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [Route("[action]/{name}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductByName(string name)
        {
            var items = await _repository.GetProductByName(name);
            if (items == null)
            {
                _logger.LogError($"Products with name: {name} not found.");
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(items));
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] ProductDto product)
        {
            await _repository.CreateProduct(_mapper.Map<Product>(product));

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto product)
        {
            return Ok(await _repository.UpdateProduct(_mapper.Map<Product>(product)));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _repository.DeleteProduct(id));
        }
    }
}
