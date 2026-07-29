using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        private List<IRoute> routes;
        private IReadOnlyCollection<IRoute> collection;

        public RouteRepository()
        {
            this.routes = new List<IRoute>();
            this.collection = new List<IRoute>();
        }

        public void AddModel(IRoute model)
        {
            routes.Add(model);
        }

        public IRoute FindById(string identifier)
        {
            return routes.FirstOrDefault(u => u.RouteId == int.Parse(identifier));
        }

        public IReadOnlyCollection<IRoute> GetAll()
        {
           return collection = routes.AsReadOnly();
        }

        public bool RemoveById(string identifier)
        {
            var route= routes.FirstOrDefault(u => u.RouteId == int.Parse(identifier));
            return routes.Remove(route);
        }
    }
}
