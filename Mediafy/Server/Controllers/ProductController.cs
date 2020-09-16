using Mediafy.Server.Interfaces;
using Mediafy.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediafy.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            var products = await _productService.GetProductsAsync();

            if (!products.Any())
            {
                _logger.LogInformation("No products available");
            }

            return products.ToArray();
        }

        [HttpPut]
        public async Task<Product> Update(Product product)
        {
            try
            {
                return await _productService.UpdateProductAsync(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Exception when calling the update method in ProductService");
                throw;
            }
        }
    }
}