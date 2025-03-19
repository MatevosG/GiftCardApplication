using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Domain.Entities.Base;
using GiftCardSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Infrastructure.Repositories
{ 
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        protected readonly DbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(GiftCardDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task AddRangeAsync(List<T> entity)
        {
            await _dbSet.AddRangeAsync(entity);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await SaveChangesAsync();
        }

        public async Task<T> GetByIdAsNoTrackingAsync(int id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await _dbSet.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public IQueryable<T> GetQuery()
        {
           return _dbSet.AsQueryable();
        }

        public IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return orderBy(query);
            return query;
        }

  

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(List<T> entities)
        {
            _dbSet.UpdateRange(entities);
            await SaveChangesAsync();
        }
        public async Task<int> SaveChangesAsync()
        {
            var context = _context as DbContext;
            var added = context.ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Added)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in added)
            {

                if (entity is EntityBase)
                {
                    var track = entity as EntityBase;
                    track.CreatedAt = DateTime.UtcNow;
                    track.UpdatedAt = DateTime.UtcNow;
                }
            }

            var modified = context.ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Modified)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in modified)
            {
                if (entity is EntityBase)
                {
                    var track = entity as EntityBase;
                    track.UpdatedAt = DateTime.UtcNow;
                }
            }

            return await context.SaveChangesAsync();
        }
    }
}
