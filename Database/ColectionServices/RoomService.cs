using Database.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Database.ColectionServices
{
    public class RoomService: ImodelService<IRoom>
    {
        private IMongoCollection<Room> Colection;
        public RoomService(IMongoDatabase db)
        {
            Colection = db.GetCollection<Room>("Room");
        }

        public async Task<IRoom> Insert(IRoom data)
        {
                Room Data = new Room()
                {
                    IdUser = data.IdUser,
                    IdApartment = data.IdApartment,
                    Name = data.Name,
                    Type = data.Type
                };

                await Colection.InsertOneAsync(Data);
                return Data;
        }

        public async Task<bool> Update(ObjectId Id,IRoom data)
        {
                Dictionary<string, object> Filter = new Dictionary<string, object>();
                //Lam sach su lieu
                if (data.IdUser != null && data.IdUser != default(ObjectId))
                {
                    Filter.Add("IdUser", data.IdUser);
                }
                if (data.IdApartment != null && data.IdApartment != default(ObjectId))
                {
                    Filter.Add("IdApartment", data.IdApartment);
                }
                if (!String.IsNullOrEmpty(data.Name))
                {
                    Filter.Add("Name", data.Name);
                }
                if (!String.IsNullOrEmpty(data.Type))
                {
                    Filter.Add("Type", data.Type);
                }
            await Colection.UpdateOneAsync(new BsonDocument() { { "_id", Id } }, new BsonDocument { { "$set", new BsonDocument().AddRange(Filter) } });
                return true;
        }

        public async Task<bool> Delete(ObjectId Id)
        {
             await Colection.DeleteOneAsync(new BsonDocument() { { "_id", Id } });
             return true;
        }

        public async Task<List<IRoom>> Get(IRoom filter)
        {
                Dictionary<string, object> Filter = new Dictionary<string, object>();
                //Lam sach su lieu
                if (filter.IdUser != null && filter.IdUser != default(ObjectId))
                {
                    Filter.Add("IdUser", filter.IdUser);
                }
                if (filter.IdApartment != null && filter.IdApartment != default(ObjectId))
                {
                    Filter.Add("IdApartment", filter.IdApartment);
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
                return a.ToEnumerable<IRoom>().ToList<IRoom>();
        }
    }
}
