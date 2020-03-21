using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Test_IndeedIdWallet.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Data { get; }

        IQueryable<T> Get(Expression<Func<T, bool>> filter = null);
        T Add(T item);
        IEnumerable<T> Add(IEnumerable<T> items);
        Task<T> AddAsync(T item);
        Task<IEnumerable<T>> AddAsync(IEnumerable<T> items);
        T Update(T item);
        IEnumerable<T> Update(IEnumerable<T> items);
        Task<T> UpdateAsync(T item);
        Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> items);
        void Delete(T item);
        void Delete(IEnumerable<T> items);
        Task DeleteAsync(T item);
        Task DeleteAsync(IEnumerable<T> items);
    }
}
