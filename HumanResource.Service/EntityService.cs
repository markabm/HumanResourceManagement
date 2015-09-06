using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HumanResource.Data.EntityFramework;
using HumanResource.Domain;
using System.Linq.Expressions;
using HumanResource.Data.EntityFramework.Data;

namespace HumanResource.Service
{
    public class EntityService<T> : IService<T> where T : class
    {
        protected IContext _context;
        protected IDbSet<T> _dbset;

        public EntityService(IContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }     

        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _dbset.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _dbset.Remove(entity);
            _context.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable<T>();
        }

        //public PaginatedList<T> GetAll(int pageIndex, int pageSize)
        //{
        //    return GetAll(pageIndex, pageSize);
        //}

        //public PaginatedList<T> GetAll(int pageIndex, int pageSize, Expression<Func<T, int>> keySelector, OrderBy orderBy = OrderBy.Ascending)
        //{
        //    return GetAll(pageIndex, pageSize, keySelector, null, orderBy);
        //}

        //public PaginatedList<T> GetAll(int pageIndex, int pageSize, Expression<Func<T, int>> keySelector, Expression<Func<T, bool>> predicate, OrderBy orderBy, params Expression<Func<T, object>>[] includeProperties)
        //{
        //    var entities = FilterQuery(keySelector, predicate, orderBy, includeProperties);
        //    var total = entities.Count();// entities.Count() is different than pageSize
        //    entities = entities.Paginate(pageIndex, pageSize);
        //    return entities.ToPaginatedList(pageIndex, pageSize, total);
        //}

        //private IQueryable<T> FilterQuery(Expression<Func<T, int>> keySelector, Expression<Func<T, bool>> predicate, OrderBy orderBy,
        //    Expression<Func<T, object>>[] includeProperties)
        //{
        //    var entities = IncludeProperties(includeProperties);
        //    entities = (predicate != null) ? entities.Where(predicate) : entities;
        //    entities = (orderBy == OrderBy.Ascending)
        //        ? entities.OrderBy(keySelector)
        //        : entities.OrderByDescending(keySelector);
        //    return entities;
        //}

        public T FindById(object Id)
        {
            return _dbset.Find(Id);
        }
    }
}
