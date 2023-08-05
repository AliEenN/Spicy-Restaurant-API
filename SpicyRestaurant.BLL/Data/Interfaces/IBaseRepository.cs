using System.Linq.Expressions;
using SpicyRestaurant.BLL.Consts;

namespace SpicyRestaurant.BLL.Data.Interfaces
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

        TEntity Find(Expression<Func<TEntity, bool>> criteria);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> criteria);

        void Add(TEntity entity);
        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void UpdateStatus(TEntity entity);

        void Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);
    }
}