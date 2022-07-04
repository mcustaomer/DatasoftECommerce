using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository( ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }
        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void InsertAll(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            _dbContext.SaveChanges();
        }

        public void Delete(object id)
        {
            var entity = _dbSet.Find(id);

            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteAll(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                _dbSet.Remove(_dbSet.Find(id));
            }

            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }

        public void UpdateAll(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
            _dbContext.SaveChanges();
        }

        public TEntity Get(object id) => _dbSet.Find(id);

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> @where) => _dbSet.Where(where);

        public IEnumerable<TEntity> GetAll() => _dbSet.AsEnumerable();

    }
}
