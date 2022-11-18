using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomGridView.DAL.Repository
{
    public interface IRepositoryBase<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
    }
}
