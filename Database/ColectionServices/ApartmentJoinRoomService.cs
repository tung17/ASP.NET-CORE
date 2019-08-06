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
    class ApartmentJoinRoomService : ImodelService<IApartmentJoinRoom>
    {
        private IMongoCollection<Room> RoomColection;
        private IMongoCollection<Apartment> ApartmentColection;
        public ApartmentJoinRoomService(IMongoDatabase db)
        {
            RoomColection = db.GetCollection<Room>("Room");
            ApartmentColection = db.GetCollection<Apartment>("Apartment");
        }

        public async Task<IApartmentJoinRoom> Insert(IApartmentJoinRoom data)
        {
            return null;
        }

        public async Task<bool> Update(ObjectId Id, IApartmentJoinRoom data)
        {
            return true;
        }
        public async Task<bool> Delete(ObjectId Id)
        {
            return true;
        }
        public async Task<List<IApartmentJoinRoom>> Get(IApartmentJoinRoom filter)
        {
            BsonDocument Filter = new BsonDocument();
            if (!String.IsNullOrEmpty(filter.Apartment.Name)) Filter.Add((new BsonElement("Name", filter.Apartment.Name)));
            List<IApartmentJoinRoom> data = ApartmentColection.Aggregate()
                    .Match(Filter)
                    .Lookup<Apartment, Room, ApartmentWithRoom>(
                        RoomColection,
                        x => x.Id,
                        y => y.IdApartment,
                        z => z.Room).ToList()
                        .Select(item => new ApartmentJoinRoom() {
                            Apartment = new Apartment() { Id = item.Id, IdUser = item.IdUser, Name = item.Name, NoApartMent = item.NoApartMent, NoFloor = item.NoFloor },
                            Room = item.Room.ToList<IRoom>()
                        })
                        .ToList<IApartmentJoinRoom>();

                return data;
        }

    }
}
