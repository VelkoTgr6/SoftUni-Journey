namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Security.Cryptography;

    [TestFixture]
    public class CarManagerTests
    {
        Car car;
        [SetUp]
        public void SetUp()
        {
            car = new("Audi", "A6", 10.5, 60);
        }
        [Test]
        public void CarShouldBeCreatedCorrectly()
        {
            string expectedMake = "Audi";
            string expectedModel = "A6";
            double expectedFuelConsumption = 10.5;
            int expectedFuelCapacity = 60;

            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
        }
        [Test]
        public void CarShouldBeCreatedWithZeroFuelAmount()
        {
            Assert.AreEqual(0, car.FuelAmount);
        }
        [TestCase(null)]
        [TestCase("")]
        //[TestCase(" ")]
        public void MakePropShouldThrowExceptionWhenValueIsNullOrEmpty(string make)
        {
            //car = new(make, "A6", 10.5, 60);
            ArgumentException exception = Assert
                .Throws<ArgumentException>(() => car = new(make, "A6", 10.5, 60));
            Assert.AreEqual("Make cannot be null or empty!", exception.Message);
        }
        [Test]
        public void MakePropShouldSetCorrectly()
        {
            string expected = "Audi";
            Assert.AreEqual(expected, car.Make);
        }
        [TestCase(null)]
        [TestCase("")]
        //[TestCase(" ")]
        public void ModelPropShouldThrowExceptionWhenValueIsNullOrEmpty(string model)
        {
            ArgumentException exception = Assert
                .Throws<ArgumentException>(() => car = new("Audi", model, 10.5, 60));
            Assert.AreEqual("Model cannot be null or empty!", exception.Message);
        }
        [Test]
        public void ModelPropShouldSetCorrectly()
        {
            string expected = "A6";
            Assert.AreEqual(expected, car.Model);
        }
        [TestCase(0)]
        [TestCase(-10)]
        [TestCase(-150.5)]
        public void FuelConsumptionPropShouldThrowExceptionWhenValueIsNegativeOr0(double fuelConsumption)
        {
            ArgumentException exception = Assert
                .Throws<ArgumentException>(() => car = new("Audi", "A6", fuelConsumption, 60));
            Assert.AreEqual("Fuel consumption cannot be zero or negative!", exception.Message);
        }
        [Test]
        public void FuelConsumptionPropShouldSetCorrectly()
        {
            double expected = 10.5;
            Assert.AreEqual(expected, car.FuelConsumption);
        }
        [Test]
        public void FuelAmountPropShouldThrowExceptionWhenValueIsNegative()
        {
            Assert.Throws<InvalidOperationException>(()
            => car.Drive(20), "Fuel amount cannot be negative!");
        }
        [TestCase(0)]
        [TestCase(-10)]
        [TestCase(-150.5)]
        public void FuelCapacityPropShouldThrowExceptionWhenValueIsNegativeOr0(double fuelCapacity)
        {
            ArgumentException exception = Assert
                .Throws<ArgumentException>(() => car = new("Audi", "A6", 10.5, fuelCapacity));
            Assert.AreEqual("Fuel capacity cannot be zero or negative!", exception.Message);
        }
        [TestCase(0)]
        [TestCase(-10.25)]
        public void RefuelMethodShouldThrowExceptionWhenValueIsNegativeOr0(double fuel)
        {
            ArgumentException exception = Assert
                .Throws<ArgumentException>(() => car.Refuel(fuel));
            Assert.AreEqual("Fuel amount cannot be zero or negative!", exception.Message);
        }
        [Test]
        public void RefuelMethodShouldWorkProperly()
        {
            car.Refuel(30.2);
            double expected = 30.2;
            Assert.AreEqual(expected, car.FuelAmount);
        }
        [Test]
        public void RefuelShouldAddFuelWhenThereIsInTheTank()
        {
            car.Refuel(20.5);
            car.Refuel(25.5);
            double expected = 46;
            Assert.AreEqual(expected, car.FuelAmount);
        }
        [Test]
        public void RefuelMethodShouldReturnFuelCapacityIfAmountIsMoreThanCapacity()
        {
            car.Refuel(85.13);
            double expected = 60;
            Assert.AreEqual(expected, car.FuelAmount);
        }
        [Test]
        public void DriveMethodShouldDecreaseFuelAmount()
        {
            double expectedResult = 8.95;

            car.Refuel(10);
            car.Drive(10);
            double actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestCase(20)]
        [TestCase(30.6)]
        public void CarDriveMethodShouldThrowExceptionIfFuelNeededIsMoreThanFuelAmount(double distance)
        {
            car.Refuel(2);
            InvalidOperationException exception = Assert
                .Throws<InvalidOperationException>(() => car.Drive(distance));
            Assert.AreEqual("You don't have enough fuel to drive!", exception.Message);

        }
    }
}