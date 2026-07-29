using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private List<IUniversity> models = new List<IUniversity>();
        public IReadOnlyCollection<IUniversity> Models => models.AsReadOnly();
        public void AddModel(IUniversity model)
        {
            models.Add(model);
        }

        public IUniversity FindById(int id)
        {
            return models.FirstOrDefault(x => x.Id == id);  
        }

        public IUniversity FindByName(string name)
        {
            return models.FirstOrDefault(m=>m.Name == name);
        }
    }
}
