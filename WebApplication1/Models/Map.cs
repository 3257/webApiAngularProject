using Newtonsoft.Json;

namespace WebApplication1.Models
{
    public class Map
    {
        public Map(string id, string name, string address, string description)
        {
            Id = id;
            Name = name;
            Address = address;
            Description = description;
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }
}