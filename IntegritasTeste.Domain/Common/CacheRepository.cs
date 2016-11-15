using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Caching;

namespace IntegritasTeste.Domain.Common
{
    /// <summary>
    /// Cache Repository
    /// </summary>
    public class CacheRepository
    {
        #region variables
        
        
        public CacheItemPolicy cacheItemPolicy { get; set; }
        #endregion
        #region Singleton
        /// <summary>
        /// The instance
        /// </summary>
        private static CacheRepository instance;
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static CacheRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = Activator.CreateInstance<CacheRepository>();
                }
                return instance;
            }
        }
        #endregion
        #region public Methods
        /// <summary>
        /// Cleans the cache.
        /// </summary>
        public void CleanCache()
        {
            ObjectCache cache = MemoryCache.Default;
            var elements = (cache.Select(c => c.Key));
            foreach (var item in elements)
            {
                cache.Remove(item);
            }
        }
        #endregion
        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CacheRepository"/> class.
        /// </summary>
        public CacheRepository()
        {
            //Set DefaultTime
            var expirationMinutes = 5;

            if (ConfigurationManager.AppSettings["MemoryCacheDefaultTime"] != null)
                expirationMinutes = int.Parse(ConfigurationManager.AppSettings["MemoryCacheDefaultTime"]);

            cacheItemPolicy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddMinutes(expirationMinutes) };
        }

        #endregion
        #region Generic setters and getters
        /// <summary>
        /// Sets a list by caching based on the termKey
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lista">The lista.</param>
        /// <param name="termKey">The term key.</param>
        public void SetListCache<T>(IList<T> lista, string termKey)
        {
            if (lista.Count >= 0)
            {
                ObjectCache cache = MemoryCache.Default;
                //Limpando o cache
                cache.Remove(termKey);
                cache.Add(termKey, lista, cacheItemPolicy);
            }
        }

        /// <summary>
        /// Get a list by caching based on the temrKey
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="termKey">The term key.</param>
        /// <returns>a T defined Object, but empty if does not exists</returns>
        public IList<T> GetListCache<T>(string termKey)
        {
            ObjectCache cache = MemoryCache.Default;
            if (cache.Contains(termKey))
                return (List<T>)cache.Get(termKey);

            return new List<T>();
        }



        /// <summary>
        /// Sets the object cache.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="termKey">The term key.</param>
        public void SetObjectCache<T>(T obj, string termKey)
        {
            ObjectCache cache = MemoryCache.Default;
            //Limpando o cache
            cache.Remove(termKey);
            cache.Add(termKey, obj, cacheItemPolicy);
        }

        /// <summary>
        /// Gets the object cache.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="termKey">The term key.</param>
        /// <returns>retorna obj vazio se não achar no cache</returns>
        public T GetObjectCache<T>(string termKey) where T : new()
        {
            ObjectCache cache = MemoryCache.Default;
            if (cache.Contains(termKey))
                return (T)cache.Get(termKey);


            return new T();
        }

        #endregion
    }
}