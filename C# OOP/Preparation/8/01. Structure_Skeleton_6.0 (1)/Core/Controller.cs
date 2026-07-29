using BookingApp.Core.Contracts;
using BookingApp.Models;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Models.RoomTypes;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;
        private BookingRepository bookings;
        private RoomRepository rooms;

        public Controller()
        {
            hotels = new HotelRepository();
            bookings = new BookingRepository();
            rooms = new RoomRepository();
        }
        public string AddHotel(string hotelName, int category)
        {
            if (hotels.Select(hotelName) !=null)
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName).TrimEnd();
            }
            var hotel=new Hotel(hotelName, category);
            hotels.AddNew(hotel);
            return string.Format(OutputMessages.HotelSuccessfullyRegistered,category, hotelName).TrimEnd();
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (this.hotels.All().FirstOrDefault(x => x.Category == category) == default)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }
            var orderedHotels =
                this.hotels.All().Where(x => x.Category == category).OrderBy(x => x.Turnover).ThenBy(x => x.FullName);


            foreach (var hotel in orderedHotels)
            {
                var selectedRoom = hotel.Rooms.All()
                    .Where(x => x.PricePerNight > 0)
                    .Where(y => y.BedCapacity >= adults + children)
                    .OrderBy(z => z.BedCapacity).FirstOrDefault();

                if (selectedRoom != null)
                {
                    int bookingNumber = this.hotels.All().Sum(x => x.Bookings.All().Count) + 1;
                    IBooking booking = new Booking(selectedRoom, duration, adults, children, bookingNumber);
                    hotel.Bookings.AddNew(booking);
                    return string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotel.FullName);
                }
            }

            return string.Format(OutputMessages.RoomNotAppropriate);
        }
            

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotels.Select(hotelName);
            if (hotel==null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName).TrimEnd();
            }
            StringBuilder sb=new StringBuilder();
            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:f2} $");
            sb.AppendLine("--Bookings:");

            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            { 
                foreach (var booking in hotel.Bookings.All())
                {
                    sb.AppendLine(booking.BookingSummary());
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel=hotels.Select(hotelName);
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName).TrimEnd();
            }
            else if (hotel.Rooms.All().Where(r => r.GetType().Name == roomTypeName) == null)
            {
                return string.Format(OutputMessages.RoomTypeNotCreated).TrimEnd();
            }
            else if (hotel.Rooms.Select(roomTypeName).PricePerNight>0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PriceAlreadySet).TrimEnd());
            }
            else
            {
                hotel.Rooms.Select(roomTypeName).SetPrice(price);
                return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName,hotelName).TrimEnd();
            }
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IRoom room;
            IHotel hotel = hotels.Select(hotelName);
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName).TrimEnd();
            }
            //rooms.Select(roomTypeName)
            else if (hotel.Rooms.Select(roomTypeName) != null)
            {
                return string.Format(OutputMessages.RoomTypeAlreadyCreated).TrimEnd();
            }
            else if (roomTypeName != nameof(Apartment) && roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Studio))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RoomTypeIncorrect,roomTypeName).TrimEnd());
            }
            else
            {
                if (roomTypeName == nameof(Apartment))
                {
                    room = new Apartment();
                    //hotel.Rooms.AddNew(room);
                }
                else if (roomTypeName == nameof(DoubleBed))
                {
                    room = new DoubleBed();
                    //hotel.Rooms.AddNew(room);
                }
                else 
                {
                    room = new Studio();
                   // hotel.Rooms.AddNew(room);
                }
                hotel.Rooms.AddNew(room);
                return string.Format(OutputMessages.RoomTypeAdded, roomTypeName,hotelName).TrimEnd();
            }
        }
    }
}
