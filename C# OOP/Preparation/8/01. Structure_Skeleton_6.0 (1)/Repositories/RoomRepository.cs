using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> rooms=new List<IRoom>();
        public void AddNew(IRoom model)
        {
            rooms.Add(model);   
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return rooms.AsReadOnly();
        }

        public IRoom Select(string roomTypeName)
        {
            return rooms.Where(r=>r.GetType().Name == roomTypeName).FirstOrDefault();
        }
    }
}
