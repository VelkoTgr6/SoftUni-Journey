using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models
{
    public class Booking : IBooking
    {
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            BookingNumber = bookingNumber;
            
        }

        public IRoom Room { get; private set; }
        public int ResidenceDuration
        {
            get { return residenceDuration; } 
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.DurationZeroOrLess).TrimEnd());
                }
                residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get { return  adultsCount; }
            private set
            {
                if (value<1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.AdultsZeroOrLess).TrimEnd());
                }
                adultsCount = value;
            }
        }

        public int ChildrenCount 
        {
            get { return  childrenCount; }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ChildrenNegative).TrimEnd());
                }
            }
        }

        public int BookingNumber {get;private set;}

        public string BookingSummary()
        {
            StringBuilder sb=new StringBuilder();
            decimal totalPaid=(decimal)Math.Round(Room.PricePerNight * ResidenceDuration,2);
                
            sb.AppendLine($"Booking number: {BookingNumber}");
            sb.AppendLine($"Room type: {Room.GetType().Name}");
            sb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            sb.AppendLine($"Total amount paid: {totalPaid:F2} $");

            return sb.ToString().TrimEnd();
        }
    }
}
