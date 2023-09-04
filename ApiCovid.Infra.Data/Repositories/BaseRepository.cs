using ApiCovid.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCovid.Infra.Data.Contexts;

namespace ApiCovid.Infra.Data.Repositories
{
    public abstract class BaseRepository<TModel, TKey>
    : IBaseRepository<TModel, TKey>
    where TModel : class
    {
        private readonly DataContext? _dataContext;
        protected BaseRepository(DataContext? dataContext)
        {
            _dataContext = dataContext;
        }
        public virtual void Add(TModel model)
        {
            _dataContext.Add(model);
            _dataContext.SaveChanges();
        }
        public virtual void Update(TModel model)
        {
            _dataContext.Entry(model).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }
        public virtual void Delete(TModel model)
        {
            _dataContext.Remove(model);
            _dataContext.SaveChanges();
        }
        public virtual List<TModel> GetAll()
        {
            return _dataContext
            .Set<TModel>()
            .ToList();
        }
        public virtual List<TModel> GetAll(Func<TModel, bool> where)
        {
            return _dataContext
            .Set<TModel>()
            .Where(where)
            .ToList();
        }
        public virtual TModel Get(Func<TModel, bool> where)
        {
            return _dataContext
            .Set<TModel>()
            .FirstOrDefault(where);
        }
        public virtual TModel GetById(TKey id)
        {
            return _dataContext
            .Set<TModel>()
            .Find(id);
        }
    }
}
