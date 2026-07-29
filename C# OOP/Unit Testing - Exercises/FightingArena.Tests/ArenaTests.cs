namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;
        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
            warrior = new("Gosho", 40, 100);
        }
        [Test]
        public void ArenaConstructorShouldWorkProperly()
        {
            Assert.IsNotNull(arena);
            Assert.IsNotNull(arena.Warriors);
        }
        [Test]
        public void CountShouldWorkProperly()
        {
            int expected = 1;

            arena.Enroll(warrior);

            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(expected, arena.Count);
        }
        [Test]
        public void EnrollMethodShouldThrowExceptionWhenWarriorNameExisting()
        {
            arena.Enroll(warrior);
            InvalidOperationException exception = Assert
                .Throws<InvalidOperationException>(() => arena.Enroll(warrior));
            Assert.AreEqual("Warrior is already enrolled for the fights!", exception.Message);
        }
        [Test]
        public void EnrollMethodShouldWorkCorrectly()
        {
            arena.Enroll(warrior);

            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(warrior, arena.Warriors.Single());
        }
        [Test]
        public void ArenaFightShouldWorkCorrectly()
        {
            Warrior defender = new("Pesho", 5, 50);

            arena.Enroll(warrior);
            arena.Enroll(defender);

            int expectedAttackerHp = 95;
            int expectedDefenderHp = 10;

            arena.Fight(warrior.Name, defender.Name);

            Assert.AreEqual(expectedAttackerHp, warrior.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }
        [Test]
        public void ArenaFightShouldThrowExceptionIfAttackerNotFound()
        {
            Warrior defender = new("Pesho", 5, 50);

            arena.Enroll(defender);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
               => arena.Fight(warrior.Name, defender.Name));

            Assert.AreEqual($"There is no fighter with name {warrior.Name} enrolled for the fights!", exception.Message);
        }
        public void ArenaFightShouldThrowExceptionIfDefenderNotFound()
        {
            Warrior defender = new("Pesho", 5, 50);

            arena.Enroll(warrior);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
               => arena.Fight(warrior.Name, defender.Name));

            Assert.AreEqual($"There is no fighter with name {defender.Name} enrolled for the fights!", exception.Message);
        }
    }
};
