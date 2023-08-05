using SpicyRestaurant.BLL.Data.Entities;

namespace SpicyRestaurant.BLL.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Category> Categories { get; }
        IBaseRepository<SubCategory> SubCategories { get; }

        int Complete();
    }
}