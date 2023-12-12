using E_commerce.Models.context;

namespace E_commerce.Models.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly AplicationDbcontext context;
        public CategoryRepository(AplicationDbcontext context)
        {
            this.context = context;
        }

        public void Add(Category p)
        {
            try
            {
                context.categories.Add(p);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some way
                Console.WriteLine($"Error adding category: {ex.Message}");
                throw; // Rethrow the exception to allow higher levels to handle it
            }

        }

        public void Delete(int id )
        {
            Category c1 = context.categories.Find(id);
            if (c1 != null)
            {
                context.categories.Remove(c1);
                context.SaveChanges();
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return context.categories;
        }

        public Category GetCategory(int id)
        {
            var c = context.categories.Find(id);
            return c;
        }

        public void Update(Category category)
        {
            Category c1 = context.categories.Find(category.Categoryid);
            if (c1 != null)
            {
                c1.Categoryname = category.Categoryname;
                context.SaveChanges();
            }
        }
    }
}
