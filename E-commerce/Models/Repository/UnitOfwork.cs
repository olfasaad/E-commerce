using E_commerce.Models.context;

namespace E_commerce.Models.Repository
{
    public class UnitOfwork : IUnitWork
    {
        readonly AplicationDbcontext context;
        public ICategoryRepository Category { get; set; }

        public IProductRepository Product { get; set; }

        public UnitOfwork(AplicationDbcontext context)
        {
            this.context = context;
            Category = new CategoryRepository(context);
            Product = new ProductRepository(context);
        }
        

        public void save()
        {
            context.SaveChanges();
        }
    }
}
