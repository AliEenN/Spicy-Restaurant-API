using Microsoft.EntityFrameworkCore;
using SpicyRestaurant.BLL.Data.Entities;

namespace SpicyRestaurant.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<SubCategory> SubCategories { get; set; } = null!;
    }
}