using Ecommerce.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Repositories.Abstractions;

public interface IRepository<TEntity> where TEntity : BaseEntity, new()
{
    //Read
    Task<ICollection<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task<bool> IsExist(int id);

    //Write
    Task<TEntity> AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    void Delete(TEntity entity);
    void SoftDelete(TEntity entity);
    void Restore(TEntity entity);
    Task SaveChangesAsync();
}