using Books.Entities;

namespace Books.Interfaces
{
    public interface IProductService
    {
        /*
         * Описуємо, які можливості мо будемо робити.
         */

        public Product[] GetAll();
        public Product GetById(int id);
        public void Create(Product product);
        public void Update(Product product);
        public void DeleteById(int id);

    }
}
