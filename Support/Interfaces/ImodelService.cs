using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Support.Interfaces
{
    public interface ImodelService<T>
    {
        Task<T> Insert(T data);
        Task<bool> Update(ObjectId Id, T data);
        Task<bool> Delete(ObjectId Id);
        Task<List<T>> Get(T filter);
    }
}
