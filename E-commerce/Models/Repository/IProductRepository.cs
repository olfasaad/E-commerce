namespace E_commerce.Models.Repository
{
    public interface IProductRepository
    {
        Product GetProduct(int id );
        IEnumerable<Product> GetAllProducts();
        void AddProduct(Product p);
        Product Update(Product p);
        void Delete(int id);


    }
}
