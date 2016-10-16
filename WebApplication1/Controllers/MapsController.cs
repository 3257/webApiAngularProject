using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MapsController : ApiController
    {
        private static readonly IMapRepository Repository = new MapRepository();

        public IEnumerable<Map> GetAllMaps()
        {
            return Repository.GetAll();
        }

        public Map GetMap(string id)
        {
            var item = Repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public HttpResponseMessage PostMap(Map item)
        {
            item = Repository.Add(item);
            var response = Request.CreateResponse(HttpStatusCode.Created, item);

            var uri = Url.Link("DefaultApi", new {id = item.Id});
            response.Headers.Location = new Uri(uri);

            return response;
        }

        public void DeleteMap(string id)
        {
            var item = Repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Repository.Remove(id);
        }

        public void DeleteAllMaps()
        {
            Repository.RemoveAll();
        }
    }
}