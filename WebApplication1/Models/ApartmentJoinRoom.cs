using Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ApartmentJoinRoom: IApartmentJoinRoom
    {
        public IApartment Apartment { get; set; }
        public List<IRoom> Room { get; set; }
    }
}
