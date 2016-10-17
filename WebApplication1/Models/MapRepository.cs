using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace WebApplication1.Models
{
    public class MapRepository : IMapRepository
    {
        public const string Url = @"C:\Users\Deyan\Source\Repos\webApiAngularProject\WebApplication1\App_Data\db2.json";
        private List<Map> maps = new List<Map>();

        public List<Map> GetAll()
        {
            // De-Serializing the gyms as a collection.
            maps = DeserializeMapsFromFile(Url);
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
            SerializeMapsToFile(Url, maps);
            return item;
        }

        public void Remove(string id)
        {
            maps.RemoveAll(p => p.Id.ToLower() == id.ToLower());

            SerializeMapsToFile(Url, maps);
        }

        public void RemoveAll()
        {
            maps.Clear();
            SerializeMapsToFile(Url, maps);
        }

        private static void SerializeMapsToFile(string urlLink, List<Map> mapsList)
        {
            File.WriteAllText(urlLink, JsonConvert.SerializeObject(mapsList));
        }

        private static List<Map> DeserializeMapsFromFile(string urlLink)
        {
            return JsonConvert.DeserializeObject<List<Map>>(File.ReadAllText(urlLink));
        }
    }
}