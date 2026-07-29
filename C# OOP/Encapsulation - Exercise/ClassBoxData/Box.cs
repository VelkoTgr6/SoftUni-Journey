using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double height;
        private double width;

        public Box(double length, double width, double height)
        {
            Length = length;
            Height = height;
            Width = width;
        }
        
        public double SurfaceArea()
        {
            return 2 * (Length*Width)+2*(Length*Height)+2*(Width*Height);
        }
        public double LateralSurfaceArea()
        {
            return 2 * (Length * Height) + 2 * (Width * Height);
        }
        public double Volume()
        {
            return Length * Width*Height;
        }

        public double Length {  get { return length; }
            private set 
            {
                if (value<=0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                length = value;
            } 
        }
        public double Height { get { return height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                height = value;
            }
        }
        public double Width { get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                width = value;
            }
        }
    }
}
