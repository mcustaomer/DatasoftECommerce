using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);

        void InsertAll(IEnumerable<TEntity> entities);

        void Delete(object id);

        void DeleteAll(IEnumerable<int> ids);

        void Update(TEntity entity);

        void UpdateAll(IEnumerable<TEntity> entities);

        TEntity Get(object id);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> @where);

        IEnumerable<TEntity> GetAll();
    }
}
