using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            Clothes = new();
            Type = type;
            Capacity = capacity;
        }
        public void AddCloth(Cloth cloth)
        {
            if(Clothes.Count<Capacity)
            Clothes.Add(cloth);
        }
        public bool RemoveCloth(string color)
        {
            Cloth removeCloth=Clothes.FirstOrDefault(c => c.Color == color);
            if (removeCloth != null)
            {
                Clothes.Remove(removeCloth);
                return true;
            }
            return false;
        }
        public Cloth GetSmallestCloth()
        {
            Cloth smallestCloth=Clothes.OrderBy(x=>x.Size).FirstOrDefault();
            return smallestCloth;
        }
        public Cloth GetCloth(string color)
        {
            Cloth cloth=Clothes.FirstOrDefault(c=>c.Color == color);
            return cloth;
        }
        public int GetClothCount()
        {
            return Clothes.Count();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Type} magazine contains:");
            foreach (var cloths in Clothes.OrderBy(c=>c.Size))
            {
                sb.AppendLine(cloths.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Cloth> Clothes { get; set; }
    }
}
