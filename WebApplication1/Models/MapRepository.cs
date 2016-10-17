using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace WebApplication1.Models
{
    public class MapRepository : IMapRepository
    {
        public const string Url = @"C:\Users\Deyan\Source\Repos\webApiAngularProject\WebApplication1\App_Data\db2.json";
        private readonly List<Map> maps = new List<Map>();

        public MapRepository()
        {
            //var map1 = new Map("Gym1", "Gym1", "Sofia,Bulgaria", "Best gym in Sofia");
            //var map2 = new Map("Gym2", "Gym2", "Dobrich,Bulgaria", "Best gym in Dobrich");
            //var map3 = new Map("Gym3", "Gym3", "Pernik,Bulgaria", "Best gym in Pernik");

            //maps.Add(map1);
            //maps.Add(map2);
            //maps.Add(map3);

            //// Serializing the gyms as a collection initially
            //SerializeMapsToFile(Url,maps);

        }

        private void SerializeMapsToFile(string urlLink,List<Map> mapsList)
        {
            File.WriteAllText(urlLink, JsonConvert.SerializeObject(mapsList));
        }

        public IEnumerable<Map> GetAll()
        {
            // De-Serializing the gyms as a collection
            var allMaps = DeserializeMapsFromFile(Url);
            return allMaps;
        }

        private static IEnumerable<Map> DeserializeMapsFromFile(string urlLink)
        {
            return JsonConvert.DeserializeObject<List<Map>>(File.ReadAllText(urlLink));
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
    }
}