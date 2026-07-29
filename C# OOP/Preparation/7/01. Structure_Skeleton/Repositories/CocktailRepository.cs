using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private List<ICocktail> cockteils;
        public CocktailRepository()
        {
            cockteils = new List<ICocktail>();
        }
        public IReadOnlyCollection<ICocktail> Models => cockteils.AsReadOnly();

        public void AddModel(ICocktail model)
        {
            cockteils.Add(model);
        }
    }
}
