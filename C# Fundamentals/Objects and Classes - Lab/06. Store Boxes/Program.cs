using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Box> boxes = new List<Box>();

            while ((input=Console.ReadLine())!="end")
            {
                string[] tokens = input.Split();
                string serialNumber = tokens[0];
                string name = tokens[1];
                int quantity = int.Parse(tokens[2]);
                decimal price = decimal.Parse(tokens[3]);

                Item item = new Item(name, price);
                Box box = new Box(serialNumber, item, quantity);
                boxes.Add(box);
            }
            foreach (Box box in boxes.OrderByDescending(x=>x.PriceBox))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.PriceBox:F2}");

            }
        }           
            
        }
        class Item
        {
            public Item(string name,decimal price)
               {
                 Name = name;
                 Price = price;
               }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
        class Box
        {
            public Box(string serialNumber,Item item,int quantity)
            {
                SerialNumber = serialNumber;
                Quantity = quantity;
                Item = item;
                

            }
            public string SerialNumber { get; set; }
            public Item Item { get; set; }
            public int Quantity { get; set; }
            public decimal PriceBox => Item.Price* Quantity;

        }
   
}
    


