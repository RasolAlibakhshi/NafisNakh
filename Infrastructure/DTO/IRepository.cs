using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Infrastructure.DTO
{
    public interface IRepository<TEntity>:IDisposable where TEntity : Base
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetBy(Expression<Func<TEntity, bool>> Filter);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
        void DeleteByID(int id);
        void SaveChanges();
    }
}
