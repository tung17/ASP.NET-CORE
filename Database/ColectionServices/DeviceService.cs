using Database.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ColectionServices
{
    public class DeviceService: ImodelService<IDevice>
    {
        private IMongoCollection<Device> Colection;
        public DeviceService(IMongoDatabase db)
        {
            Colection = db.GetCollection<Device>("Device");
        }

        public async Task<IDevice> Insert(IDevice data)
        {
                Device Data = new Device()
                {
                    IdUser = data.IdUser,
                    IdRoom = data.IdRoom,
                    Status = data.Status,
                    Type = data.Type,
                    Name = data.Name
                };

                await Colection.InsertOneAsync(Data);
                return Data;
        }

        public async Task<bool> Update(ObjectId Id, IDevice data)
        {
                await Colection.UpdateOneAsync(new BsonDocument() { { "_id", Id } }, new BsonDocument() {
                    { "IdUser",data.IdUser},
                    { "IdRoom",data.IdRoom},
                    { "Status",data.Status},
                    { "Type",data.Type},
                    {"Name",data.Name }
                });
                return true;
        }

        public async Task<bool> Delete(ObjectId Id)
        {
                await Colection.DeleteOneAsync(new BsonDocument() { { "_id", Id } });
                return true;
        }

        public async Task<List<IDevice>> Get(IDevice filter)
        {
            Dictionary<string, object> Filter = new Dictionary<string, object>();
            if (filter.Id != null && filter.Id != default(ObjectId))
            {
                Filter.Add("_id", filter.Id);
            }
            if (filter.IdUser != null && filter.IdUser != default(ObjectId))
            {
                Filter.Add("IdUser", filter.IdUser);
            }
            if (filter.IdRoom != null && filter.IdRoom != default(ObjectId))
            {
                Filter.Add("IdRoom", filter.IdRoom);
            }
            if (!String.IsNullOrEmpty(filter.Status))
            {
                Filter.Add("Name", filter.Status);
            }
            if (!String.IsNullOrEmpty(filter.Name))
            {
                Filter.Add("Name", filter.Name);
            }
            if (!String.IsNullOrEmpty(filter.Type))
            {
                Filter.Add("Type", filter.Type);
            }
            var a = await Colection.FindAsync(new BsonDocument().AddRange(Filter));
                return a.ToEnumerable<IDevice>().ToList<IDevice>();
        }
    }
}
