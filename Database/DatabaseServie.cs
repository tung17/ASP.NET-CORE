using Database.ColectionServices;
using Database.Models;
using Microsoft.Win32.SafeHandles;
using MongoDB.Bson;
using MongoDB.Driver;
using Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DatabaseService: IDatabaseService
    {
        private const string connectionString = "mongodb://gmgttt:1234@localhost:27017/local?authSource=admin";
        private IMongoDatabase db;
        public DatabaseService()
        {
            var mongoUrl = new MongoUrl(connectionString);
            var client = new MongoClient(mongoUrl);
            var session = client.StartSession();
            db = session.Client.GetDatabase("local");
            Task.Run(async () =>
            {
                if (await CollectionExistsAsync("room", db))
                    await db.CreateCollectionAsync("room");
                if (await CollectionExistsAsync("apartment", db))
                    await db.CreateCollectionAsync("apartment");
                if (await CollectionExistsAsync("device", db))
                    await db.CreateCollectionAsync("device");
            });
            deviceModel = new DeviceService(db);
            roomModel = new RoomService(db);
            apartmentModel = new ApartmentService(db);
            apartmentModelJoinRoom = new ApartmentJoinRoomService(db);
        }

        private ImodelService<IDevice> deviceModel;
        public ImodelService<IDevice> DeviceModel { get { return deviceModel; } }

        private ImodelService<IRoom> roomModel;
        public ImodelService<IRoom> RoomModel { get { return roomModel; }}

        private ImodelService<IApartment> apartmentModel;
        public ImodelService<IApartment> ApartmentModel { get { return apartmentModel; }}

        private ImodelService<IApartmentJoinRoom> apartmentModelJoinRoom;
        public ImodelService<IApartmentJoinRoom> ApartmentModelJoinRoom { get { return apartmentModelJoinRoom; } }

        public async Task<bool> CollectionExistsAsync(string collectionName, IMongoDatabase _db)
        {
            var filter = new BsonDocument("name", collectionName);
            //filter by collection name
            try
            {
                var collections = await _db.ListCollectionsAsync(new ListCollectionsOptions { Filter = filter });
                return await collections.AnyAsync();
            }
            catch (Exception e)
            {
                return false;
            }
            //check for existence
        }
    }
}
