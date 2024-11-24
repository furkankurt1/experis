
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityRepository<T>
        where T : class, IEntity
    {
        T Add(T entity);
        Task<ICollection<T>> AddBulkAsync(ICollection<T> entities);
        T Update(T entity);
        void Delete(T entity);
        void DeleteRange(ICollection<T> entities);
        IEnumerable<T> GetList(Expression<Func<T, bool>> expression = null);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression = null);
        T Get(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        IQueryable<T> Query();
    }
}