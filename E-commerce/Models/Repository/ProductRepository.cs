using E_commerce.Models.context;
using E_commerce.Models.ViewModels;

namespace E_commerce.Models.Repository
{
    public class ProductRepository : IProductRepository
    {

        readonly AplicationDbcontext context;
        public ProductRepository (AplicationDbcontext context)
        {
            this.context = context;
        }

        public void AddProduct(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
          
        }

        public void Delete(int id)
        {
            Product product = context.Products.Find(id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products;
        }

        public Product GetProduct(int id)
        {
            return context.Products.Find(id);
        }

        public Product Update(Product p)
        {
            Product c1 = context.Products.Find(p.productid);
            if (c1 != null)
            {
                c1.productname = p.productname;
                c1.price = p.price;
               c1.categoryid = p.categoryid;
                c1.photo = p.photo;
                c1.productDescription = p.productDescription;
             
                context.SaveChanges();

            }
            return c1 ;
        }
    }
}
