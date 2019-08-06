using Database.Models;
using Microsoft.Win32.SafeHandles;
using MongoDB.Bson;
using MongoDB.Driver;
using Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Database.ColectionServices
{
    public class ApartmentService: ImodelService<IApartment>, IDisposable
    {
        bool disposed = false;
        private IMongoCollection<Apartment> Colection;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public ApartmentService(IMongoDatabase db)
        {
            Colection = db.GetCollection<Apartment>("Apartment");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }

        public async Task<IApartment> Insert(IApartment data)
        {
                Apartment Data = new Apartment()
                {
                    IdUser = data.IdUser,
                    Name = data.Name,
                    NoFloor = data.NoFloor,
                    NoApartMent = data.NoApartMent
                };

                await Colection.InsertOneAsync(Data);
                return Data;
        }

        public async Task<bool> Update(ObjectId Id, IApartment data)
        {
            Dictionary<string, object> Data = new Dictionary<string, object>();
            //Lam sach su lieu
            if (data.IdUser != null && data.IdUser != default(ObjectId))
                Data.Add("IdUser", data.IdUser);
            if (!String.IsNullOrEmpty(data.Name))
                Data.Add("Name", data.Name);
            if (data.NoFloor != 0)
                Data.Add("NoFloor", data.NoFloor);
            if (data.NoApartMent != 0)
                Data.Add("NoApartMent", data.NoApartMent);
            await Colection.UpdateOneAsync(new BsonDocument() { { "_id", Id } }, new BsonDocument { { "$set", new BsonDocument().AddRange(Data) } });
                return true;
        }

        public async Task<bool> Delete(ObjectId Id)
        {
                await Colection.DeleteOneAsync(new BsonDocument() { { "_id", Id } });
                return true;
        }

        public async Task<List<IApartment>> Get(IApartment filter)
        {
            //https://stackoverflow.com/questions/14129421/get-property-of-generic-class
            Dictionary<string, object> Filter = new Dictionary<string, object>();
            //Lam sach su lieu
            if (filter.IdUser != null && filter.IdUser != default(ObjectId))
                Filter.Add("IdUser", filter.IdUser);
            if (!String.IsNullOrEmpty(filter.Name))
                Filter.Add("Name", filter.Name);
            if (filter.NoFloor != 0)
                Filter.Add("NoFloor", filter.NoFloor);
            if(filter.NoApartMent != 0)
                Filter.Add("NoApartMent", filter.NoApartMent);

            var a = await Colection.FindAsync(new BsonDocument().AddRange(Filter));
            return a.ToList<IApartment>();
        }
    }
}
