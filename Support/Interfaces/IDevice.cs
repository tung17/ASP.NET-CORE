using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace Support.Interfaces
{
    public interface IDevice
    {
        ObjectId Id { get; set; }
        ObjectId IdUser { get; set; }
        ObjectId IdRoom { get; set; }
        string stringIdRoom { get; set; }
        string Type { get; set; }
        string Status { get; set; }
        string Name { get; set; }
    }
}
