using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        private List<IBooth>boots = new List<IBooth>();
        public IReadOnlyCollection<IBooth> Models => boots.AsReadOnly();

        public void AddModel(IBooth model)
        {
            boots.Add(model);
        }
    }
}
