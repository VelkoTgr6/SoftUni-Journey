using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.RoomTypes
{
    public class DoubleBed : Room
    {
        private const int _bedCapacity = 2;
        public DoubleBed() : base(_bedCapacity)
        {
        }
    }
}
