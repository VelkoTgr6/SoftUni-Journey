using NUnit.Framework;
using System;
using System.Threading;
using System.Xml.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Planet planet;
            private Weapon weapon;
            [SetUp]
            public void SetUp()
            {
                planet = new Planet("Dagobah", 5.5);
                weapon = new Weapon("Nuke", 1.5, 3);


            }
            [Test]
            public void IsPlanetConstructorSettingCorrectly()
            {

                var planet = new Planet("Dagobah", 5.5);
                string expectedName = "Dagobah";
                double expectedBudget = 5.5;
                Assert.AreEqual(expectedName, planet.Name);
                Assert.AreEqual(expectedBudget, planet.Budget);
            }
            [TestCase("")]
            [TestCase(null)]
            public void IsNameThrowingExceptionWhenNullOrWhitespace(string name) 
            {
                Planet planet;
                ArgumentException exception = Assert
                .Throws<ArgumentException>(() => planet = new Planet(name, 5.5));
                Assert.AreEqual("Invalid planet Name", exception.Message);
            }
            [Test]
            public void BudgetShouldThrowExceptionWhenValueIsNegative()
            {
                Planet planet;
                ArgumentException exception = Assert
                .Throws<ArgumentException>(() => planet = new Planet("Dagobah",-1));
                Assert.AreEqual("Budget cannot drop below Zero!", exception.Message);
            }
            [Test]
            public void ProfitShouldAddAmount()
            {
                var planet = new Planet("Dagobah", 5.5);
                planet.Profit(1.0);
                double expectedBudget = 6.5;
                Assert.AreEqual(expectedBudget, planet.Budget);
            }
            [Test]
            public void SpendFundsShouldWorkCorrectly()
            {
                var planet = new Planet("Dagobah", 5.5);
                planet.SpendFunds(1.0);
                double expectedBudget = 4.5;
                Assert.AreEqual(expectedBudget, planet.Budget);
            }
            [Test]
            public void SpendFundsShouldThrowExceptionWhenAmountIsGreaterThanBudget()
            {
                var planet = new Planet("Dagobah", 5.5);
                double expectedBudget = 5.5;
                InvalidOperationException exception = Assert
                .Throws<InvalidOperationException>(() => planet.SpendFunds(7.0)); 
                Assert.AreEqual($"Not enough funds to finalize the deal.", exception.Message);
                Assert.AreEqual(expectedBudget, planet.Budget);
            }
            [Test]
            public void AddWeaponShouldWorkCorrectly()
            {
                planet.AddWeapon(weapon);
                var expectedName = "Nuke";
                double expectedPrice = 1.5;
                int expectedDestructionLevel = 3;

                Assert.AreEqual(1, planet.Weapons.Count);

            }
            [Test]
            public void UpgradeWeaponShouldWorkCorrectly()
            {
                planet.AddWeapon(weapon);   
                planet.UpgradeWeapon("Nuke");
                var expectedDestructionLevel = 4;

                Assert.AreEqual(expectedDestructionLevel, weapon.DestructionLevel);
            }
            [Test]
            public void UpgradeWeaponShouldThrowExceptionWhenWeaponNotFound()
            {
                
                InvalidOperationException exception = Assert
               .Throws<InvalidOperationException>(() => planet.UpgradeWeapon("loli"));
                Assert.AreEqual($"loli does not exist in the weapon repository of {planet.Name}", exception.Message);
                
            }
            [Test]
            public void AddWeaponShouldThrowExceptionWhenNameExists()
            {
                var weapone = new Weapon("Nuke",1.2, 33);
                planet.AddWeapon(weapon);
                InvalidOperationException exception = Assert
                .Throws<InvalidOperationException>(() => planet.AddWeapon(weapone));
                Assert.AreEqual($"There is already a {weapone.Name} weapon.", exception.Message);
                
            }
            [Test]
            public void RemoveWeaponShouldWorkProperly()
            {
                planet.AddWeapon(weapon);
                Assert.AreEqual(1,planet.Weapons.Count);
                planet.RemoveWeapon("Nuke");
                Assert.AreEqual(0,planet.Weapons.Count);
            }
            [Test]
            public void DestructOpponentShouldThrowExceptionWhenMorePower()
            {
                var opponent = new Planet("Gogo", 500);
                var opponentWeapon = new Weapon("zag", 5, 10);

                InvalidOperationException exception = Assert
                .Throws<InvalidOperationException>(() => planet.DestructOpponent(opponent));
                Assert.AreEqual($"{opponent.Name} is too strong to declare war to!", exception.Message);
            }
            [Test]
            public void DestructOpponentShouldWorkCorrectly()
            {
                planet.AddWeapon(weapon);
                var opponent = new Planet("Gogo", 500);
                var opponentWeapon = new Weapon("zag", 1, 1);
                opponent.AddWeapon(opponentWeapon);

                Assert.AreEqual($"{opponent.Name} is destructed!",planet.DestructOpponent(opponent));
            }
        }
    }
}
