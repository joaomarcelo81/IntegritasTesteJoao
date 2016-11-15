using System;
using System.Collections.Generic;
using IntegritasTeste.Domain.Entities;
using IntegritasTeste.Domain.Interface.Aplications;
using IntegritasTeste.Domain.Interface.Repositories;

namespace IntegritasTeste.Application
{
    public class BaseApplication<TEntity> : IDisposable, IBaseApplication<TEntity> where TEntity : EntityBase
    {
        private readonly IBaseRepository<TEntity> _serviceBase;

        public BaseApplication(IBaseRepository<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        }

        public TEntity Get(long id)
        {
            return _serviceBase.Get(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public void SaveAndUpdate(TEntity obj)
        {
            _serviceBase.SaveAndUpdate(obj);
        }
        public void Save()
        {
            _serviceBase.Save();
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}