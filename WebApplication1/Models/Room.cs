using MongoDB.Bson;
using Support.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Room:IRoom
    {
        public ObjectId Id { get; set; }
        public ObjectId IdUser { get; set; }
        public ObjectId IdApartment { get; set; }
        public string stringApartment { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
