using System.Linq.Expressions;

namespace BartTest.Repository.Infrastructure
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<int> SaveChangesAsync();
        void Delete(TEntity entity);

    }
}
