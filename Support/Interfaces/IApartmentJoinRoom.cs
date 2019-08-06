using System;
using System.Collections.Generic;
using System.Text;

namespace Support.Interfaces
{
    public interface IApartmentJoinRoom
    {
        IApartment Apartment { get; set; }
        List<IRoom> Room { get; set; }
    }
}
