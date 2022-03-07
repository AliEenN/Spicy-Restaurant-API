using SpicyRestaurant.BLL.Interfaces;
using SpicyRestaurant.BLL.Models;
using SpicyRestaurant.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
