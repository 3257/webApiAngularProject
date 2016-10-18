using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebApplication1.Models.UtilityClasses
{
    public class MapsWrapper
    {
        [JsonProperty("mapsData")]
        public List<Map> MapsData { get; set; }
    }
}