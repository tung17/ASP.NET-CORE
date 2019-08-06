using MongoDB.Bson;
using Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Device:IDevice
    {
        public ObjectId Id { get; set; }
        public ObjectId IdUser { get; set; }
        public ObjectId IdRoom { get; set; }
        public string stringIdRoom { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
    }
}
