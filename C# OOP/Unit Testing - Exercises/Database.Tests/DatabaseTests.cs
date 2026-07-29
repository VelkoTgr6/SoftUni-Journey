namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        [SetUp]
        public void SetUp()
        {
            database = new Database(2,3);
        }

        [Test]
        public void DatabaseConstructorShouldWorkCorrectly()
        {
            int[] expected = new int[] {2,3};
            Assert.AreEqual(expected, database.Fetch());
        }

        [Test]
        public void DatabaseCountShouldBeCorrect()
        {
            int expected = 2;
            
            Assert.NotNull(database);
            Assert.AreEqual(expected, database.Count);
        }

        [TestCase(new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17})]
        public void AddMethodShouldThrowExceptionCountIsMoreThan16(int[]data)
        {
            InvalidOperationException exception = Assert
                .Throws<InvalidOperationException>(() =>database=new Database(data));
            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [TestCase(new int [] { 1, 2, 3, 4, 5, 6, 7 })]
        public void DatabaseShouldAddElementsCorrectly(int[]data)
        {
            database=new(data);
            int [] actual=database.Fetch();

            Assert.AreEqual(data, actual);
        }

        [TestCase(-3)]
        [TestCase(1)]
        public void DatabaseAddMethodShouldIncreaseCount(int number)
        {
            int expected = 3;
            database.Add(number);
            Assert.AreEqual(expected, database.Count);
        }

        [Test]
        public void DatabaseRemoveMethodShouldThrowExceptionWhenCountIs0orNegative()
        {
            database = new();
            InvalidOperationException exception = Assert
               .Throws<InvalidOperationException>(() => database.Remove());
            Assert.AreEqual("The collection is empty!",exception.Message);

        }

        [Test]
        public void RemoveMethodShouldDecreaseCount()
        {
            int expected = 1;
            database.Remove();
            Assert.AreEqual(expected, database.Count);
        }

        [Test]
        public void RemoveMethodShouldRemoveElementsCorrectly()
        {
            int[] expected = new int[] { };
            database.Remove();
            database.Remove();
            Assert .AreEqual(expected, database.Fetch());
        }

        [TestCase(new int[] {1,2,3,4 })]
        public void FetchMethodShouldWorkCorrectly(int[]data)
        {
            database=new(data);
            Assert.AreEqual(data, database.Fetch());
        }
    }
}
