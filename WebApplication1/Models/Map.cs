using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
 
    public class Map
    {
        private string id;
        private string name;
        private string address;
        private string description;

        public Map(string id, string name, string address, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Description = description;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
    }
}