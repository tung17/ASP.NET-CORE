using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Support.Interfaces
{
    public interface IRoom
    {
        ObjectId Id { get; set; }
        ObjectId IdUser { get; set; }
        ObjectId IdApartment { get; set; }
        string Type { get; set; }
        string Name { get; set; }
    }
}
