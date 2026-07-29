using System;
using System.Collections.Generic;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        List<Type> shapes= new List<Type>() { typeof(Circle),typeof(Rectangle),typeof(Square)};
        public void DrawShape(  )
        {
            foreach (var shape2 in shapes)
            {
                
                TellShape(shape2);
            }
        }
        private void TellShape(Type shape)
        {
            Console.WriteLine($"I'm {shape.Name}");
        }
    }
}
