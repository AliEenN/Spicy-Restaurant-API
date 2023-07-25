using Microsoft.EntityFrameworkCore;
using SpicyRestaurant.BLL.Consts;
using SpicyRestaurant.BLL.Data.Interfaces;
using SpicyRestaurant.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> craitria)
        {
            return _context.Set<TEntity>().Where(craitria).ToList();
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
            return _context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public TEntity GetByObjectId(object id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetByObjectIdAsync(object id)
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

        public void Edit(TEntity entity)
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
