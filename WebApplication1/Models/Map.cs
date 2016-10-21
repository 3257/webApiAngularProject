using System;
using Newtonsoft.Json;

namespace WebApplication1.Models
{
    public class Map
    {
        private string id;
        private string name;
        private string description;
        private string address;

        public Map(string id, string name, string address, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Description = description;
        }

        [JsonProperty("id")]
        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Id cannot be null");
                }

                this.id = value;
            }
        }

        [JsonProperty("name")]
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null");
                }

                if (value.Length<3||value.Length>15)
                {
                    throw new ArgumentOutOfRangeException("Name must be between 3 and 15 letters long");
                }

                this.name = value;
            }
        }

        [JsonProperty("address")]
        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Address cannot be null");
                }
                if (value.Length < 3 || value.Length > 25)
                {
                    throw new ArgumentOutOfRangeException("Address must be between 3 and 25 letters long");
                }

                this.address = value;
            }
        }

        [JsonProperty("description")]
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Description cannot be null");
                }
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new ArgumentOutOfRangeException("Description must be between 3 and 30 letters long");
                }

                this.description = value;
            }
        }
    }
}