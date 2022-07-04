using DataAccessLayer.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Generic
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public void Insert(TEntity entity) => _genericRepository.Insert(entity);

        public void InsertAll(IEnumerable<TEntity> entities) => _genericRepository.InsertAll(entities);

        public void Delete(object id) => _genericRepository.Delete(id);

        public void DeleteAll(IEnumerable<int> ids) => _genericRepository.DeleteAll(ids);

        public void Update(TEntity entity) => _genericRepository.Update(entity);

        public void UpdateAll(IEnumerable<TEntity> entities) => _genericRepository.UpdateAll(entities);

        public TEntity Get(object id) => _genericRepository.Get(id);

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> @where) => _genericRepository.GetAll(where);
        
        public IEnumerable<TEntity> GetAll() => _genericRepository.GetAll();
    }
}
