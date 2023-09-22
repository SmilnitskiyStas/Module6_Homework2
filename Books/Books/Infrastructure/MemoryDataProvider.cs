using Books.Entities;
using Books.Interfaces;

namespace Books.Infrastructure
{
    public class MemoryDataProvider : IDataProvider
    {
        private List<Product> _data = new List<Product>() { new Product() { Id = 1, Title = "Harry", Author = "Tom", YearOfCreate = DateTime.Parse("1999.10.12"), Price = 14.99m } };
        public void CreateProduct(Product product)
        {
            _data.Add(product);
        }

        public void DeleteProductById(int id)
        {
            _data.Remove(GetProductById(id));
        }

        public Product[] GetAllProducts()
        {
            return _data.ToArray();
        }

        public Product GetProductById(int id)
        {
            return _data.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateProduct(Product product)
        {
            Product existingProduct = _data.FirstOrDefault(p => p.Id == product.Id);

            if (existingProduct != null)
            {
                existingProduct.Title = product.Title;
                existingProduct.Author = product.Author;
                existingProduct.YearOfCreate = product.YearOfCreate;
                existingProduct.Price = product.Price;
            }
        }
    }
}
