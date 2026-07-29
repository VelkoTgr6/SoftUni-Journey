using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> hotelList = new List<IHotel>();
        public void AddNew(IHotel model)
        {
            hotelList.Add(model);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return hotelList.AsReadOnly();
        }

        public IHotel Select(string hotelName)
        {
            return hotelList.Where(r => r.FullName == hotelName).FirstOrDefault();
        }
    }
}
