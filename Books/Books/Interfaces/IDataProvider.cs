using Books.Entities;

namespace Books.Interfaces
{
    public interface IDataProvider
    {
        /*
         * Описуємо, які можливості ми будемо робити із базою.
         */

        public Product[] GetAllProducts();
        public Product GetProductById(int id);
        public void CreateProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProductById(int id);
    }
}
