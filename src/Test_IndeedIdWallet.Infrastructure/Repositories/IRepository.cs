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

        IQueryable<T> Get(Expression<Func<T, bool>> filter);
        T Add(T item);
        Task<T> AddAsync(T item);
        T Update(T item);
        Task<T> UpdateAsync(T item);
        void Delete(T item);
        Task DeleteAsync(T item);
    }
}
