
using System.ComponentModel.DataAnnotations;

namespace MiniORM
{
    public class ChangeTracker<T> where T : class,new()
    {
        private readonly List<T> _allEntities;
        private readonly List<T> _added;
        private readonly List<T> _removed;

        public ChangeTracker(IEnumerable<T> entites)
        {
            _added = new List<T>();
            _removed = new List<T>();
            _allEntities=CloneEntities(entites);
        }
        public IReadOnlyCollection<T> AllEntities => _allEntities.AsReadOnly();
        public IReadOnlyCollection<T> Added => _added.AsReadOnly();
        public IReadOnlyCollection<T> Deleted => _removed.AsReadOnly();

        public void Add(T entity) =>_added.Add(entity);
        public void Remove(T entity) =>_removed.Remove(entity); 

        private List<T> CloneEntities(IEnumerable<T> entites)
        {
            var clonedEntites=new List<T>();
            var propertiesToClone=typeof(T).GetProperties()
                .Where(pi=>DbContext.AllowedSqlTypes.Contains(pi.PropertyType)).ToArray();

            foreach (var entity in entites) 
            {
                var clonedEntity = Activator.CreateInstance<T>();
                foreach (var property in propertiesToClone) 
                {
                    var value = property.GetValue(entity);
                    property.SetValue(clonedEntity, value);
                }
                clonedEntites.Add(clonedEntity);
            }
            return clonedEntites;
        }

        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet) 
        {
            var modifiedEntities = new List<T>();
            System.Reflection.PropertyInfo[] primaryKeys = typeof(T).GetProperties()
                .Where(pi=>pi.HasAttribute<KeyAttribute>()).ToArray();


        }
    }
}