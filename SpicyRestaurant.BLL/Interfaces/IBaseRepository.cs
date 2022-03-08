using SpicyRestaurant.BLL.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpicyRestaurant.BLL.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> craitria);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> craitria);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, object>> orderBy, string orderByDirection = OrderBy.Ascending);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, object>> orderBy, string orderByDirection = OrderBy.Ascending);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> craitria, Expression<Func<TEntity, object>> orderBy, string orderByDirection = OrderBy.Ascending);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> craitria, Expression<Func<TEntity, object>> orderBy, string orderByDirection = OrderBy.Ascending);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, object>> orderBy, string[] includes, string orderByDirection = OrderBy.Ascending);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, object>> orderBy, string[] includes, string orderByDirection = OrderBy.Ascending);

        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);

        TEntity GetByObjectId(object id);
        Task<TEntity> GetByObjectIdAsync(object id);

        TEntity Find(Expression<Func<TEntity, bool>> criteria);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> criteria);

        void Add(TEntity entity);
        Task AddAsync(TEntity entity);

        void Edit(TEntity entity);

        void Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
