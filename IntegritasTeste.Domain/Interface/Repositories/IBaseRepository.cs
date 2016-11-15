using System;
using System.Collections.Generic;
using IntegritasTeste.Domain.Entities;

namespace IntegritasTeste.Domain.Interface.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : EntityBase
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        TEntity Get(long id);
        IEnumerable<TEntity> GetAll();
        void Save();
        void SaveAndUpdate(TEntity obj);
        void Dispose();
    }
}
