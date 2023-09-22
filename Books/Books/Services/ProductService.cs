using Books.Entities;
using Books.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Books.Services
{
    public class ProductService : IProductService
    {
        // За інжектили провайдер, для того щоб можна було отримувати данні із (бази, пам'яті, файлів).
        private readonly IDataProvider _dataProvider;

        public ProductService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public void Create(Product product)
        {
            if (_dataProvider.GetProductById(product.Id) != null)
            {
                return;
            }

            _dataProvider.CreateProduct(CreateIdForProduct(product));
        }

        public void DeleteById(int id)
        {
            _dataProvider.DeleteProductById(id);
        }

        public Product[] GetAll()
        {
            return _dataProvider.GetAllProducts();
        }

        public Product GetById(int id)
        {
            return _dataProvider.GetProductById(id);
        }

        public void Update(Product product)
        {
            if (_dataProvider.GetProductById(product.Id) == null)
            {
                return;
            }

            _dataProvider.UpdateProduct(product);
        }

        private Product CreateIdForProduct(Product product)
        {
            Product[] products = _dataProvider.GetAllProducts();

            product.Id = products.Length + 1;

            return product;
        }
    }
}
