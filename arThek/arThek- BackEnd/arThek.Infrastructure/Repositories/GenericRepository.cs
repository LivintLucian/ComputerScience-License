using arThek.Entities.BaseEntities;
using arThek.Entities.Entities;
using arThek.Entities.RepositoryInterfaces;
using arThek.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arThek.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly arThekContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(arThekContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        #region CRUD

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var entityFromDB = (await _dbSet.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();

            return entityFromDB;
        }
        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet
                .ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .SingleOrDefaultAsync(x => x.Id == id);
        }
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entityFromDB = (_dbSet.Update(entity)).Entity;
            await _context.SaveChangesAsync();

            return entityFromDB;
        }

        #endregion
    }
}
