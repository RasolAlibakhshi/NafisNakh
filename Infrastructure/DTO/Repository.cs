using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DTO
{
    public class Repository<TEntity>:IRepository<TEntity> where TEntity : Base
    {
        private Context _context;
        private DbSet<TEntity> _dbSet;

        public Repository(Context context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public TEntity GetBy(Expression<Func<TEntity, bool>> Filter)
        {
            IQueryable<TEntity> query = _dbSet;
            if (Filter != null)
            {
                TEntity data= query.Where(Filter).FirstOrDefault();
                return data;
            }

            return null;
        }

        public TEntity Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _context.Set<TEntity>().Entry(entity).State= EntityState.Modified;
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            _context.Set<TEntity>().Entry(entity).State=EntityState.Deleted;
            return entity;
        }

        public void DeleteByID(int id)
        {
            _context.Set<TEntity>().Entry(GetBy(x=>x.ID==id)).State= EntityState.Deleted;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
