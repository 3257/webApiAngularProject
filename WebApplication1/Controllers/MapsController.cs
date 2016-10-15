using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MapsController : ApiController
    {
        static readonly IMapRepository repository = new MapRepository();

        public IEnumerable<Map> GetAllMaps()
        {
            return repository.GetAll();

        }

        public Map GetMap(string id)
        {
            Map item = repository.Get(id);
            if (item==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public HttpResponseMessage PostMap(Map item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Map>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new {id = item.Id});
            response.Headers.Location = new Uri(uri);

            return response;
        }

        public void DeleteMap(string id)
        {
            Map item = repository.Get(id);
            if (item==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repository.Remove(id);
        }

        public void DeleteAllMaps()
        {
            repository.RemoveAll();
        }
    }
}
