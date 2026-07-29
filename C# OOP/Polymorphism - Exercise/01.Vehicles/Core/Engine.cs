using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Vehicles.Core.Interfaces;
using Vehicles.Factories.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core;

public class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly IVehicleFactory factory;

    private readonly ICollection<IVehicle> vehicles;

    public Engine(IReader reader, IWriter writer, IVehicleFactory factory)
    {
        this.reader = reader;
        this.writer = writer;
        this.factory = factory;
        vehicles = new List<IVehicle>();
    }

    public void Run()
    {
        vehicles.Add(CreateVehicle());
        vehicles.Add(CreateVehicle());
        vehicles.Add(CreateVehicle());

        int commandsCount = int.Parse(reader.ReadLine());

        for (int i = 0; i < commandsCount; i++)
        {
            try
            {
                ProcessCommand();
            }
            catch(Exception ex) 
            {
                writer.WriteLine(ex.Message);
            }
        }
        foreach (var vehicle in vehicles)
        {
            writer.WriteLine(vehicle.ToString());
        }
    }
    private IVehicle CreateVehicle()
    {
        string[]tokens=reader.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
        return factory.Create(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]), int.Parse(tokens[3]));
        
    }
    private void ProcessCommand()
    {
        string[] tokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string command= tokens[0];
        string type= tokens[1];
        double distance= double.Parse(tokens[2]);

        IVehicle vehicle=vehicles.FirstOrDefault(v=>v.GetType().Name ==type);
        if(vehicle == null)
        {
            throw new ArgumentException("invalid vehicle type");
        }
        if (command == "Drive")
        {
            writer.WriteLine(vehicle.Drive(distance));
        }
        else if (command == "Refuel")
        {
            vehicle.Refuel(distance);
        }
        else if(command == "DriveEmpty")
        {
            vehicle.DriveEmpty(distance);
        }
    }
}