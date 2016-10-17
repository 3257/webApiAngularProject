using System.Collections.Generic;

namespace WebApplication1.Models
{
    internal interface IMapRepository
    {
        List<Map> GetAll();
        Map Get(string id);
        Map Add(Map item);
        void Remove(string id);
        void RemoveAll();
    }
}