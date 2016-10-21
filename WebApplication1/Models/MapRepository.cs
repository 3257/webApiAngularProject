using System;
using System.Collections.Generic;
using WebApplication1.Models.UtilityClasses;

namespace WebApplication1.Models
{
    public class MapRepository : IMapRepository
    {
        public const string Url = @"C:\Users\Deyan\Source\Repos\webApiAngularProject\WebApplication1\App_Data\db.json";

        private readonly MapsWrapper mapsWrapper = new MapsWrapper
        {
            MapsData = new List<Map>()
        };

        public IEnumerable<Map> GetAll()
        {
            // De-Serializing the gyms as coming from fake DB a collection.
            mapsWrapper.MapsData = Serializer.DeserializeMapsFromFile(Url);
            return mapsWrapper.MapsData;
        }

        // This method is used mainly for practice purposes.
        public Map Get(string id)
        {
            return mapsWrapper.MapsData.Find(p => p.Id.ToLower() == id.ToLower());
        }

        public Map Add(Map item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Map item cannot be null");
            }

            mapsWrapper.MapsData.Add(item);
            Serializer.SerializeMapsToFile(Url, mapsWrapper);
            return item;
        }

        public void Remove(string id)
        {
            mapsWrapper.MapsData.RemoveAll(p => p.Id.ToLower() == id.ToLower());

            Serializer.SerializeMapsToFile(Url, mapsWrapper);
        }

        public void RemoveAll()
        {
            mapsWrapper.MapsData.Clear();
            Serializer.SerializeMapsToFile(Url, mapsWrapper);
        }
    }
}