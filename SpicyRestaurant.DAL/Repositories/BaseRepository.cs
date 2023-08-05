using System.Linq.Expressions;
using SpicyRestaurant.DAL.Data;
using SpicyRestaurant.BLL.Consts;
using Microsoft.EntityFrameworkCore;
using SpicyRestaurant.BLL.Data.Interfaces;

namespace SpicyRestaurant.DAL.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> craitria)
        {
            return _context.Set<TEntity>().Where(craitria).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> craitria)
        {
            return await _context.Set<TEntity>().Where(craitria).ToListAsync();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, object>> orderBy, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (orderByDirection == OrderBy.Descending)
                query = query.OrderByDescending(orderBy);

            query = query.OrderBy(orderBy);

            return query.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, object>> orderBy, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (orderByDirection == OrderBy.Descending)
                query = query.OrderByDescending(orderBy);

            query = query.OrderBy(orderBy);

            return await query.ToListAsync();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> craitria, Expression<Func<TEntity, object>> orderBy, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().Where(craitria);

            if (orderByDirection == OrderBy.Descending)
                query = query.OrderByDescending(orderBy);

            query = query.OrderBy(orderBy);

            return query.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> craitria, Expression<Func<TEntity, object>> orderBy, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().Where(craitria);

            if (orderByDirection == OrderBy.Descending)
                query = query.OrderByDescending(orderBy);

            query = query.OrderBy(orderBy);

            return await query.ToListAsync();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, object>> orderBy, string[] includes, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            foreach (var include in includes)
                query = query.Include(include);

            if (orderByDirection == OrderBy.Descending)
                query = query.OrderByDescending(orderBy);

            query = query.OrderBy(orderBy);

            return query.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, object>> orderBy, string[] includes, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            foreach (var include in includes)
                query = query.Include(include);

            if (orderByDirection == OrderBy.Descending)
                query = query.OrderByDescending(orderBy);

            query = query.OrderBy(orderBy);

            return await query.ToListAsync();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id)!;
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> criteria)
        {
            return _context.Set<TEntity>().SingleOrDefault(criteria);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> criteria)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(criteria);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void UpdateStatus(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
    }
}