using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.RoomTypes
{
    public class Apartment : Room
    {
        private const int _bedCapacity = 6;
        public Apartment() : base(_bedCapacity)
        {
        }
    }
}
