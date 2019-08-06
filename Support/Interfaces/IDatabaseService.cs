using System;
using System.Collections.Generic;
using System.Text;

namespace Support.Interfaces
{
    public interface IDatabaseService
    {
        ImodelService<IDevice> DeviceModel { get;}
        ImodelService<IRoom> RoomModel { get;}
        ImodelService<IApartment> ApartmentModel { get; }
        ImodelService<IApartmentJoinRoom> ApartmentModelJoinRoom { get; }
    }
}
