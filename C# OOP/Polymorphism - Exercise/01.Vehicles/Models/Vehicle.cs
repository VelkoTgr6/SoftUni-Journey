using System;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models;

public abstract class Vehicle : IVehicle
{
    private double increasedConsumption;
    private double fuelQuantity;

    protected Vehicle(double fuelQuantity, double fuelConsumption, double increasedConsumption, int tankCapacity)
    {
        TankCapacity = tankCapacity;
        FuelQuantity = fuelQuantity;
        
        FuelConsumption = fuelConsumption;
        this.increasedConsumption = increasedConsumption;
        
    }

    public double FuelQuantity
    {
        get => fuelQuantity;
        private set
        {
            if (TankCapacity < value)
            {
                fuelQuantity = 0;
            }
            else
            {
                fuelQuantity = value;
            }
        }
    }
    public double FuelConsumption { get; private set; }
    public int TankCapacity {get;private set;}

    public string Drive(double distance)
    {
        double consumption = increasedConsumption + FuelConsumption;
        if (FuelQuantity<distance*consumption)
        {
            throw new ArgumentException($"{GetType().Name} needs refueling");
        }
        FuelQuantity-=distance*consumption;
        return $"{GetType().Name} travelled {distance} km";
    }
    public string DriveEmpty(double distance)
    {
        if (FuelQuantity < distance*FuelConsumption )
        {
            throw new ArgumentException($"{GetType().Name} needs refueling");
        }
        FuelQuantity -= distance;
        return $"{GetType().Name} travelled {distance} km";
    }

    public virtual void Refuel(double amount)
    {
        if (amount+FuelQuantity > TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
        }
        if(amount <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        FuelQuantity += amount;
    }
    public override string ToString()
    {
        return $"{GetType().Name}: {FuelQuantity:f2}";
    }
}
