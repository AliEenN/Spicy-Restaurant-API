using SpicyRestaurant.DAL.Data;
using SpicyRestaurant.BLL.Data.Entities;
using SpicyRestaurant.BLL.Data.Interfaces;

namespace SpicyRestaurant.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepository<Category> Categories { get; private set; }
        public IBaseRepository<SubCategory> SubCategories { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Categories = new BaseRepository<Category>(_context);
            SubCategories = new BaseRepository<SubCategory>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}