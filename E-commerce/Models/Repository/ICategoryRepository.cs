

namespace E_commerce.Models.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        void Update(Category category);
        Category GetCategory(int id);
        
        void Add(Category p);
        
        void Delete(int id);
        
    }
}
