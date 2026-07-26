using Raw_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tires[] tires;

        public Car(string model, int speed,int power, int weight, string type, double tyrePressure1,int tyreAge1,
            double tyrePressure2, int tyreAge2, double tyrePressure3, int tyreAge3, double tyrePressure4, int tyreAge4)
        {
            Model = model;
            Engine = new (speed,power);
            Cargo = new(type,weight);
            Tires = new Tires[4];
            Tires[0] = new(tyreAge1, tyrePressure1);
            Tires[1] = new(tyreAge2 , tyrePressure2);
            Tires[2] = new(tyreAge3 , tyrePressure3);
            Tires[3] = new(tyreAge4 , tyrePressure4);
        }

        public string Model { get { return model; } set {  model = value; } }
        public Engine Engine { get { return engine; } set { engine = value; } }
        public Cargo Cargo { get {  return cargo; } set {  cargo = value; } }
        public Tires[] Tires { get {  return tires; } set {  tires = value; } }

    }
}
