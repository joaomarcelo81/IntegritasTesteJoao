using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using IntegritasTeste.DataContext.DataContext;
using IntegritasTeste.Domain.Entities;
using IntegritasTeste.Domain.Interface.Repositories;

namespace IntegritasTeste.DataContext.Repositories
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : EntityBase
    {
        
            protected IntegritasTesteDataContext Db;
            public IntegritasTesteDataContext Context;

            private DbContextTransaction dbTran;
            //http://www.entityframeworktutorial.net/entityframework6/transaction-in-entity-framework.aspx


            public BaseRepository(IntegritasTesteDataContext _context)
            {
                Context = _context;
                this.Db = _context;



            }

            public void Add(TEntity obj)
            {
                Db.Set<TEntity>().Add(obj);
            }

            public void Update(TEntity obj)
            {
                Db.Entry(obj).State = EntityState.Modified;

            }

            public void Remove(TEntity obj)
            {
                Db.Set<TEntity>().Remove(obj);
            }

            public TEntity Get(long id)
            {
                return Db.Set<TEntity>().Find(id);
            }

            public IEnumerable<TEntity> GetAll()
            {
                return Db.Set<TEntity>().ToList();
            }
            public TEntity GetByParams(Func<TEntity, bool> lambda)
            {
                return Db.Set<TEntity>().Where<TEntity>(lambda).FirstOrDefault();
            }

            public IEnumerable<TEntity> FinByParams(Func<TEntity, bool> lambda)
            {
                return Db.Set<TEntity>().Where<TEntity>(lambda);
            }

            public IEnumerable<TEntity> FinByParams(Func<IEnumerable<TEntity>, IEnumerable<TEntity>> query)
            {
                return query(Db.Set<TEntity>()).ToList();
            }

            public void SaveAndUpdate(TEntity obj)
            {

                //    bool saveFailed;
                //    do
                //    {
                //        saveFailed = false;

                //        try
                //        {
                //            Db.SaveChanges();
                //        }
                //        catch (DbUpdateConcurrencyException ex)
                //        {
                //            saveFailed = true;

                //            // Update the values of the entity that failed to save from the store 
                //            ex.Entries.Single().Reload();
                //        } 

                //    } while (saveFailed); 


                Db.Set<TEntity>().AddOrUpdate();
            }


            public void Save()
            {

                //    bool saveFailed;
                //    do
                //    {
                //        saveFailed = false;

                //        try
                //        {
                //            Db.SaveChanges();
                //        }
                //        catch (DbUpdateConcurrencyException ex)
                //        {
                //            saveFailed = true;

                //            // Update the values of the entity that failed to save from the store 
                //            ex.Entries.Single().Reload();
                //        } 

                //    } while (saveFailed); 


                var saida = Db.SaveChanges();
            }

            public void BeginTransaction()
            {
                dbTran = Context.Database.BeginTransaction();
            }

            public void CommitTransaction()
            {
                dbTran.Commit();
            }

            public void RollbackTransaction()
            {
                dbTran.Rollback();
            }

            private bool disposed = false;

            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        Db.Dispose();
                    }
                }
                this.disposed = true;
            }

            public void Dispose()
            {

                if (dbTran != null)
                    dbTran.Dispose();

                Dispose(true);
                GC.SuppressFinalize(this);

            }

            /*
          
                    #region Dispose
            private IntPtr nativeResource = Marshal.AllocHGlobal(100);
            public void Dispose()
            {
                if (nativeResource != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(nativeResource);
                    nativeResource = IntPtr.Zero;
                }
                GC.SuppressFinalize(this);
            }
            #endregion
          
              */
        }



}
