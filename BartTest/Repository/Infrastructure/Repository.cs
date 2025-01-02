using System.Linq.Expressions;
using System.Security.Principal;
using BartTest.Context;
using BartTest.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BartTest.Repository.Infrastructure
{
    public sealed class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly BartDbContext _context;
        private readonly DbSet<TEntity> _dbEntities;

        public Repository(BartDbContext context)
        {
            _context = context;
            _dbEntities = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes)
        {
            var dbSet = _context.Set<TEntity>();
            var query = includes.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(dbSet, (current, include) => current.Include(include));

            return query ?? dbSet;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            CheckEntityForNull(entity);
            return (await _dbEntities.AddAsync(entity)).Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity) =>
           await Task.Run(() => _dbEntities.Update(entity).Entity);


        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();

        public void Delete(TEntity entity) => _context.Entry(entity).State = EntityState.Deleted;

        private static void CheckEntityForNull(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "The entity to add cannot be null.");
            }
        }
    }
}
