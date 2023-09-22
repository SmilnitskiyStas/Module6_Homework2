using Books.Entities;
using Books.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        // За інжектили наш сервіс із контролером.
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public Product[] GetAllProduct()
        {
            return _productService.GetAll();
        }

        [HttpGet]
        [Route("/[controller]/{id}")]
        public Product GetProductById(int id)
        {
            return _productService.GetById(id);
        }

        [HttpPost]
        public void CreateProduct([FromBody] Product product)
        {
            _productService.Create(product);
        }

        [HttpPut]
        public void UpdateProduct(Product product)
        {
            _productService.Update(product);
        }

        [HttpDelete]
        public void DeleteProductById(int id)
        {
            _productService.DeleteById(id);
        }
    }
}
