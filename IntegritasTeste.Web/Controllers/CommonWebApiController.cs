using System.Collections.Generic;
using System.Web.Http;
using IntegritasTeste.Application;
using IntegritasTeste.Domain.Entities;
using IntegritasTeste.Domain.Interface.Aplications;
using IntegritasTeste.Domain.Interface.Repositories;

namespace IntegritasTeste.Web.Controllers
{
    public class CommonWebApiController<TEntity> : ApiController where TEntity : EntityBase
    {
        protected IBaseApplication<TEntity> app;

        // GET api/<controller>
        public IEnumerable<TEntity> Get()
        {
            return app.GetAll();
        }

        // GET api/<controller>/5
        public TEntity Get(long Id)
        {

            return app.Get(Id);
        }

        // POST api/<controller>
        public void Post([FromBody]TEntity value)
        {
            app.Add(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]TEntity value)
        {
            app.Update(value);
        }

        // DELETE api/<controller>/5
        public void Delete(TEntity value)
        {
            app.Remove(value);
        }
    }
}
