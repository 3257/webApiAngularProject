using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class MapRepository : IMapRepository
    {
        private readonly List<Map> maps = new List<Map>();
 

        public MapRepository()
        {
            Add(new Map("Gym1", "Gym1", "Sofia,Bulgaria", "Best gym in Sofia"));
            Add(new Map("Gym2", "Gym2", "Dobrich,Bulgaria", "Best gym in Dobrich"));
            Add(new Map("Gym3", "Gym3", "Pernik,Bulgaria", "Best gym in Pernik"));
        }

        public IEnumerable<Map> GetAll()
        {
            return maps;
        }

        public Map Get(string id)
        {
            return maps.Find(p => p.Id.ToLower() == id.ToLower());
        }

        public Map Add(Map item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Map item cannot be null");
            }

            maps.Add(item);
            return item;
        }

        public void Remove(string id)
        {
            maps.RemoveAll(p => p.Id.ToLower() == id.ToLower());
        }

        public void RemoveAll()
        {
            maps.Clear();
        }
    }
}