using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    interface IMapRepository
    {

        IEnumerable<Map> GetAll();
        Map Get(string id);
        Map Add(Map item);
        void Remove(string id);
        void RemoveAll();
    }
}
