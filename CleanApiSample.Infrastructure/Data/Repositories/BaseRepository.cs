﻿using CleanApiSample.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanApiSample.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
            => await _dbSet.AsNoTracking()
                           .ToListAsync(cancellationToken);
        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
            => await _dbSet.FindAsync(id, cancellationToken);
        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var updatedEntity = _dbSet.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return updatedEntity.Entity;
        }
        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var createdEntity = await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync();
            return createdEntity.Entity;
        }
        public async Task DeleteAsync(int id, CancellationToken cancellation)
        {
            _dbSet.Remove(await _dbSet.FindAsync(id, cancellation));
            _context.SaveChangesAsync(cancellation);
        }
    }
}
