using Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class ApartmentWithRoom: Apartment
    {
        public List<Room> Room { get; set; }
    }

    public class ApartmentJoinRoom : IApartmentJoinRoom
    {
        public IApartment Apartment { get; set; }
        public List<IRoom> Room { get; set; }
    }
}
