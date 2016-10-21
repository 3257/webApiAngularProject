using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace WebApplication1.Models.UtilityClasses
{
    public class Serializer
    {
        public static void SerializeMapsToFile(string urlLink, MapsWrapper mapsWrappedObjectToSerialize)
        {
            File.WriteAllText(urlLink, JsonConvert.SerializeObject(mapsWrappedObjectToSerialize));
        }

        public static List<Map> DeserializeMapsFromFile(string urlLink)
        {
            var mapsWrappedObjectToDeserialize = JsonConvert.DeserializeObject<MapsWrapper>(File.ReadAllText(urlLink));
            return mapsWrappedObjectToDeserialize.MapsData;
        }
    }
}