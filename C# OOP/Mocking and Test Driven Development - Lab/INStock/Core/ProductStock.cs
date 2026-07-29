using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INStock.Core
{
    public class ProductStock : IProductStock
    {
        ICollection<IProduct> products=new List<IProduct>();
        public IProduct this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int IProductStock.Count => throw new NotImplementedException();

        public void Add(IProduct product)
        {
            products.Add(product);
        }
            
        public bool Contains(IProduct product)
        {
            var containingProduct= products.Where(p=>p.Label==product.Label);
            if (containingProduct != default)
                return true;

            return false;
        }

        public IProduct Find(int index)
        {
            IProduct [] arr=products.ToArray();
            return arr[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            ICollection<IProduct> productsByPrice = new HashSet<IProduct>();
            foreach (var product in products.Where(p=>p.Price== (decimal)price))
            {
                productsByPrice.Add(product);
            }
            return productsByPrice;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            ICollection<IProduct> productsByQiantity = new HashSet<IProduct>();
            foreach (var product in products.Where(p => p.Quantity == quantity))
            {
                productsByQiantity.Add(product);
            }
            return productsByQiantity;
        }

        public IEnumerable<IProduct> FindAllInrangeAll(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IProduct FindByLabel(string label)
        {
            return products.First(p=> p.Label==label);    
        }

        public IProduct FindMostExpensiveProduct()
        {
           return products.First(p=>p.Price==products.Max(p=>p.Price)); 
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            return products.GetEnumerator();
        }

        public bool Remove(IProduct product)
        {
            if (products.Contains(product))
            {
                products.Remove(product);
                return true;  
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
