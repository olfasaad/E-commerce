namespace E_commerce.Models.ViewModels
{
    public class CategoryVm
    {
        public Category category { get; set; } = new Category();
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
