using SpicyRestaurant.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyRestaurant.BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Category> Categories { get; }
        IBaseRepository<SubCategory> SubCategories { get; }

        int Complete();
    }
}