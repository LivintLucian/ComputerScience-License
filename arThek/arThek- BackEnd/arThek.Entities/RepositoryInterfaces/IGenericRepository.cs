using arThek.Entities.BaseEntities;
using arThek.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace arThek.Entities.RepositoryInterfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
