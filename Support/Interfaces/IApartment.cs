using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Support.Interfaces
{
    public interface IApartment
    {
        ObjectId Id { get; set; }
        ObjectId IdUser { get; set; }
        string Name { get; set; }
        int NoFloor { get; set; }
        int NoApartMent { get; set; }
    }
}
