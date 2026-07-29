using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Repositories.Contracts;
using EDriveRent.Models.Contracts;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> Users;
        public UserRepository() 
        {
            Users = new List<IUser>();
        }
        public void AddModel(IUser model)
        {
            Users.Add(model);
        }

        public IUser FindById(string identifier)
        {
            return Users.FirstOrDefault(u=>u.DrivingLicenseNumber == identifier);
        }

        public IReadOnlyCollection<IUser> GetAll()
        {
            return Users.AsReadOnly();
        }

        public bool RemoveById(string identifier)
        {
           return Users.Remove(FindById(identifier));
        }
    }
}
