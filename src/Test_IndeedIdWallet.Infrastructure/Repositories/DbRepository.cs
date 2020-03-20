using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Test_IndeedIdWallet.Infrastructure.Repositories
{
    public class DbRepository<T> : IRepository<T> where T : class
    {
        public IQueryable<T> Data { get; }
        private DbSet<T> _table;
        private ApplicationDbContext _ctx;

        public DbRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
            _table = _ctx.Set<T>();
            Data = _table.AsTracking();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null)
        {
            var result = Data.AsNoTracking();

            if (filter != null)
            {
                result = result.Where(filter);
            }

            return result;
        }

        public T Add(T item)
        {
            _table.Add(item);
            _ctx.SaveChanges();
            return item;
        }

        public async Task<T> AddAsync(T item)
        {
            await _table.AddAsync(item);
            await _ctx.SaveChangesAsync();
            return item;
        }

        public T Update(T item)
        {
            _table.Update(item);
            _ctx.SaveChanges();
            return item;
        }

        public async Task<T> UpdateAsync(T item)
        {
            _table.Update(item);
            await _ctx.SaveChangesAsync();
            return item;
        }

        public void Delete(T item)
        {
            _table.Remove(item);
            _ctx.SaveChanges();

        }

        public async Task DeleteAsync(T item)
        {
            _table.Remove(item);
            await _ctx.SaveChangesAsync();
        }
    }
}
