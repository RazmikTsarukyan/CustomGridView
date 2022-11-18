using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomGridView.DAL.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DataContext DataContext { get; set; }
        public RepositoryBase(DataContext repositoryContext)
        {
            DataContext = repositoryContext;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await DataContext.Set<T>().ToListAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await DataContext.Set<T>().AddAsync(entity);
            await DataContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            DataContext.Set<T>().Update(entity);
            await DataContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            DataContext.Set<T>().Remove(entity);
            await DataContext.SaveChangesAsync();

            return entity;
        }

        public async Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await DataContext.Set<T>().Where(expression).ToListAsync();
        }
    }
}
