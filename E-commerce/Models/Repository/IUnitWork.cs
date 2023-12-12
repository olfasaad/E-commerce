namespace E_commerce.Models.Repository
{
    public interface IUnitWork
    {

        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        void save();
    }
}
