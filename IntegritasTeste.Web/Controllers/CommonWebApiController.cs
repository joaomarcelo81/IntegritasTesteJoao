using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntegritasTeste.Application;
using IntegritasTeste.Domain.Common;
using IntegritasTeste.Domain.Entities;
using IntegritasTeste.Domain.Interface.Aplications;
using IntegritasTeste.Domain.Interface.Repositories;
using Resources;

namespace IntegritasTeste.Web.Controllers
{
    public abstract class CommonWebApiController<TEntity> : ApiController where TEntity : EntityBase
    {
        protected IBaseApplication<TEntity> app;


        public virtual IEnumerable<TEntity> Get()
        {
            return app.GetAll();
        }

   
        public virtual HttpResponseMessage Get(long Id)
        {
            var item = app.Get(Id);
            if (item == null)
            {
                var message = string.Format("Product with id = {0} not found", Id);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
        }

  
        public HttpResponseMessage Post([FromBody]TEntity value)
        {
            try
            {
                app.Add(value);
                
            }
            catch (Exception ex)
            {
                ex.Log("teste");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, GlobalResources.GenericErrorMessage);   
                
            }
            return Request.CreateResponse(HttpStatusCode.OK, value);
        }

     
        public HttpResponseMessage Put(int id, [FromBody]TEntity value)
        {
            app.Update(value);
            return Request.CreateResponse(HttpStatusCode.OK, value);
        }

  
        public void Delete(TEntity value)
        {
            app.Remove(value);
        }
    }
}
