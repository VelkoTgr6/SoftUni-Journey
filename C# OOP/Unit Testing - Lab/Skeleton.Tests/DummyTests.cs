using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private int attack = 5;
        private int durability = 6;
        private int health= 7;
        private int experience = 8;
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(attack, durability);
            dummy = new Dummy(health, experience);
        }
        [Test]
        public void When_HealthIsProvided_ShouldBeSetCorrectly()
        {
            Assert.AreEqual(dummy.Health,health);
        }
        [Test]
        public void When_Attacked_ShouldDecreaseHealth()
        {
            int attackPoints = 3;
            dummy.TakeAttack(attackPoints);

            Assert.That(dummy.Health, Is.EqualTo(health - attackPoints), "Dummy doesn't loose health when attacked");
        }
        [Test]
        public void When_Dummy_IsAttacked_ShouldLoseHealth()
        {
            dummy.TakeAttack(attack);
            Assert.AreEqual(health - attack, dummy.Health);
        }

        [Test]
        public void When_Dummy_IsDead_ShouldThrowException()
        {
            dummy = new(0, 0);
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(attack));
        }
        [Test]
        public void When_Dummy_IsDead_ShouldReturnXP()
        {
            dummy = new(0, 5);
            dummy.GiveExperience();
        }
        [Test]
        public void When_HealthIsNegative_ShouldBeDead()
        {
            dummy = new(-5, 0);
            Assert.That(dummy.IsDead(), Is.EqualTo(true));
        }
        [Test]
        public void When_Dummy_IsAlive_ShouldNot_GiveXP()
        {
            Assert.Throws<InvalidOperationException>( () => dummy.GiveExperience());
        }

    }
}