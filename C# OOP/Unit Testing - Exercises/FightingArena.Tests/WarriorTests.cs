namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        Warrior warrior;
        [SetUp]
        public void SetUp()
        {
            warrior = new("Grisho", 40, 100);
        }
        [Test]
        public void WarriorShouldBeCreatedCorrectly()
        {
            string expectedName = "Grisho";
            int expectedDmg = 40;
            int expectedHP= 100;

            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDmg, warrior.Damage);
            Assert.AreEqual(expectedHP, warrior.HP);
        }
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void WarriorNameShouldThrowExceptionWhenIsNullOrWhitespace(string name)
        {
            ArgumentException exception = Assert
                .Throws<ArgumentException>(() => warrior = new(name, 20, 100));
            Assert.AreEqual("Name should not be empty or whitespace!",exception.Message);
        }
        [TestCase(0)]
        [TestCase(-10)]
        [TestCase(-200)]
        public void WarriorDamageShouldThrowExceptionWhenValueIsNegativeOr0(int damage)
        {
            ArgumentException exception = Assert
                .Throws<ArgumentException>(() => warrior = new("Grisho",damage, 100));
            Assert.AreEqual("Damage value should be positive!", exception.Message);
        }
        [TestCase(-10)]
        [TestCase(-200)]
        public void WarriorHPShouldThrowExceptionWhenValueIsNegativeOr0(int HP)
        {
            ArgumentException exception = Assert
                .Throws<ArgumentException>(() => warrior = new("Grisho", 20, HP));
            Assert.AreEqual("HP should not be negative!", exception.Message);
        }
        [Test]
        public void AttackMethodShouldWorkCorrectly()
        {
            int expectedAtackerHp = 95;
            int expectedDefenderHp = 80;

            Warrior attacker = new("Pesho", 10, 100);
            Warrior defender = new("Gosho", 5, 90);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAtackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }
        [TestCase(28)]
        [TestCase(30)]
        public void AttackMethodShouldReturnExceptionWhenHPisBellowOrEqualTo30(int HP)
        {
            warrior=new("Grisho", 20, HP);
            Warrior enemy = new("Pesho", 20, 40);
            
            InvalidOperationException exception = Assert
                .Throws<InvalidOperationException>(() => warrior.Attack(enemy));
            Assert.AreEqual("Your HP is too low in order to attack other warriors!", exception.Message);
        }
        [TestCase(28)]
        [TestCase(30)]
        public void AttackMethodShouldReturnExceptionWhenEnemyHPisBellowOrEqualTo30(int HP)
        {
            Warrior enemy = new("Pesho", 20, HP);

            InvalidOperationException exception = Assert
                .Throws<InvalidOperationException>(() => warrior.Attack(enemy));
            Assert.AreEqual("Enemy HP must be greater than 30 in order to attack him!", exception.Message);
        }
        [Test]
        public void AttackMethodShouldReturnExceptionWhenEnemyDamageIsGreaterThanWarriorHP()
        {
            Warrior enemy = new("Pesho", 300, 100);

            InvalidOperationException exception = Assert
                .Throws<InvalidOperationException>(() => warrior.Attack(enemy));
            Assert.AreEqual("You are trying to attack too strong enemy", exception.Message);
        }
        [Test]
        public void AttackMethodShouldReduceEnemyHPTo0_WhenWarriorDamageIsGreaterThanEnemyHP()
        {
            Warrior enemy = new("Pesho", 35, 35);
            warrior.Attack(enemy);
            int expected = 0;
            Assert.AreEqual(expected, enemy.HP);
        }

    }
}