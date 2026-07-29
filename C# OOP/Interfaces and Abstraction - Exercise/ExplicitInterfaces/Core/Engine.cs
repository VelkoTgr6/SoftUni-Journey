using ExplicitInterfaces.Core.Interfaces;
using ExplicitInterfaces.IO.Intercases;
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Intercases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaces.Core
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        //private readonly IPerson person;

        public Engine(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
            
           
        }

        public void Run()
        {
            string input;
            while ((input=reader.ReadLine())!="End")
            {
                string[]tokens= input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                IPerson person=new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));
                writer.WriteLine(tokens[0]);
                writer.WriteLine(person.GetName(tokens[0]));
                
            }
        }
    }
}
