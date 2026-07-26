using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericScale
{
    internal class EqualityScale<T>
    {
        public T Left { get; set; }
        public T Right { get; set; }
        public EqualityScale(T left, T right)
        {
            Left = left;
            Right = right;
        }
        public bool AreEqual()
        {
            return Left.Equals(Right);
        }

    }
}
