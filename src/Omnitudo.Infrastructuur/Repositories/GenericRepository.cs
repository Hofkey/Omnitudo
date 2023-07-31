using Microsoft.EntityFrameworkCore;
using Omnitudo.Core.Entities;
using Omnitudo.Core.Exceptions.Entities;
using Omnitudo.Core.Interfaces;
using Omnitudo.Infrastructuur.Database;
using System.Linq.Expressions;

namespace Omnitudo.Infrastructuur.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DatabaseContext context;

        protected DbSet<TEntity> dbSet;

        public GenericRepository(DatabaseContext context)
        {
            this.context = context;

            dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query.AsNoTracking());
            }
            else
            {
                return query.AsNoTracking();
            }
        }

        public TEntity? GetById(Guid id)
        {
            return dbSet.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }

        public virtual async Task Create(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = GetById(id);

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(TEntity), id);
            }

            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
