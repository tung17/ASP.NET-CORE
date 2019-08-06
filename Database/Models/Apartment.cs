using MongoDB.Bson;
using Support.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Models
{
    public class Apartment:IApartment
    {
        public ObjectId Id { get; set; }
        public ObjectId IdUser { get; set; }
        public string Name { get; set; }
        public int NoFloor { get; set; }
        public int NoApartMent { get; set; }
    }
}
