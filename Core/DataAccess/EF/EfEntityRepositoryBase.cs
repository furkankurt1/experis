using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework;

public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity where TContext : DbContext
{
    public EfEntityRepositoryBase(TContext context)
    {
        Context = context;
    }

    protected TContext Context { get; }

    public TEntity Add(TEntity entity)
    {
        return Context.Add(entity).Entity;
    }

    public async Task<ICollection<TEntity>> AddBulkAsync(ICollection<TEntity> entities)
    {
        await Context.AddRangeAsync(entities);
        return entities;
    }

    public void DeleteRange(ICollection<TEntity> entities)
    {
        Context.RemoveRange(entities);
    }

    public TEntity Update(TEntity entity)
    {
        Context.Update(entity);
        return entity;
    }


    public void Delete(TEntity entity)
    {
        Context.Remove(entity);
    }


    public TEntity Get(Expression<Func<TEntity, bool>> expression)
    {
        return Context.Set<TEntity>().FirstOrDefault(expression);
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await Context.Set<TEntity>().AsQueryable().FirstOrDefaultAsync(expression);
    }

    public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null)
    {
        return expression == null
            ? Context.Set<TEntity>().AsNoTracking()
            : Context.Set<TEntity>().Where(expression).AsNoTracking();
    }

    public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression = null)
    {
        return expression == null
            ? await Context.Set<TEntity>().ToListAsync()
            : await Context.Set<TEntity>().Where(expression).ToListAsync();
    }


    public int SaveChanges()
    {
        return Context.SaveChanges();
    }

    public Task<int> SaveChangesAsync()
    {
        return Context.SaveChangesAsync();
    }

    public IQueryable<TEntity> Query()
    {
        return Context.Set<TEntity>();
    }
}