namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            
            Person[] persons =
           {new Person(1, "Pesho"),
            new Person(2, "Gosho"),
            new Person(3, "Ivan_Ivan"),
            new Person(4, "Pesho_ivanov"),
            new Person(5, "Gosho_Naskov"),
            new Person(6, "Pesh-Peshov"),
            new Person(7, "Ivan_Kaloqnov"),
            new Person(8, "Ivan_Draganchov"),
            new Person(9, "Asen"),
            new Person(10, "Jivko"),
            new Person(11, "Toshko")};

            database = new(persons);
        }
        [Test]
        public void CreatingDatabaseCountShouldBeCorrect()
        {
            int expected = 11;
            Assert.AreEqual(expected, database.Count);
        }
        [Test]
        public void CreatingDatabaseShouldThrowExceptionWhenCountIsMoreThan16()
        {
            Person[] persons =
           {new Person(1, "Pesho"),
            new Person(2, "Gosho"),
            new Person(3, "Ivan_Ivan"),
            new Person(4, "Pesho_ivanov"),
            new Person(5, "Gosho_Naskov"),
            new Person(6, "Pesh-Peshov"),
            new Person(7, "Ivan_Kaloqnov"),
            new Person(8, "Ivan_Draganchov"),
            new Person(9, "Asen"),
            new Person(10, "Jivko"),
            new Person(11, "Toshko"),
            new Person(12, "Moshko"),
            new Person(13, "Foshko"),
            new Person(14, "Loshko"),
            new Person(15, "Roshko"),
            new Person(16, "Boshko"),
            new Person(17, "Kokoshko")};

            ArgumentException exception = Assert
                .Throws<ArgumentException>(() => database = new Database(persons));
            Assert.AreEqual("Provided data length should be in range [0..16]!", exception.Message);
        }
        [Test]
        public void DatabaseCountShouldWorkCorrectly()
        {
            int expected = 11;
            Assert.AreEqual(expected, database.Count);
        }
        [Test]
        public void AddMethodShouldIncreaseCountCorrectly()
        {
            var person = new Person(12, "Velko");
            database.Add(person);
            int expected = 12;
            Assert.AreEqual(expected, database.Count);
        }
        [Test]
        public void DatabaseAddMethodShouldWorkCorrectly()
        {
            var person = new Person(12, "Velko");
            database.Add(person);
            int expected = 12;
            Assert.AreEqual(expected, database.Count);
        }
        [Test]
        public void DatabaseAddMethodShouldThrowExceptionIfCountIsMoreThan16()
        {
            Person person1 = new(12, "John");
            Person person2 = new(13, "Paul");
            Person person3 = new(14, "Green");
            Person person4 = new(15, "Brown");
            Person person5 = new(16, "Killer");

            database.Add(person1);
            database.Add(person2);
            database.Add(person3);
            database.Add(person4);
            database.Add(person5);

            InvalidOperationException exception = Assert
                .Throws<InvalidOperationException>(() => database.Add(new Person(17, "Zvezda")));
            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }
        [Test]
        public void DatabaseAddMethodShouldThrowExceptionIfNameAlreadyExists()
        {
            InvalidOperationException exception = Assert
               .Throws<InvalidOperationException>(() => database.Add(new Person(15,"Pesho")));
            Assert.AreEqual("There is already user with this username!",exception.Message);
        }
        [Test]
        public void DatabaseAddMehodShouldThrowExceptionIfIDAlreadyExists() 
        {
            InvalidOperationException exception = Assert
               .Throws<InvalidOperationException>(() => database.Add(new Person(1, "Zvezda")));
            Assert.AreEqual("There is already user with this Id!", exception.Message);
        }
        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            int expected = 10;
            database.Remove();
            Assert.AreEqual(expected, database.Count);
        }
        [Test]
        public void RemoveMethodCountShouldWorkCorrectly()
        {
            int expected = 10;
            database.Remove();
            Assert.AreEqual(expected, database.Count);
        }
        [Test]
        public void RemoveMethodShouldThrowExceptionWhenCountIs0()
        {
            database = new();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void FindUsernameMethodShouldWorkCorrectly()
        {
            string expected = "Pesho";
            Assert.AreEqual(expected,database.FindByUsername("Pesho").UserName);
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void FindByUsernameMethodShouldThrowExceptionWhenUsernameIsNullOrWhitespace(string name)
        {
            ArgumentNullException exception=Assert
                .Throws<ArgumentNullException>(()=> database.FindByUsername(name));
            Assert.AreEqual("Username parameter is null!", exception.ParamName);
        }
        [Test]
        [TestCase("zvezda")]
        public void FindByUsernameMethodShouldThrowExceptionWhenUsernameIsNotFound(string name)
        {
            InvalidOperationException exception = Assert
                .Throws<InvalidOperationException>(() => database.FindByUsername(name));
            Assert.AreEqual("No user is present by this username!", exception.Message);
        }
        [Test]
        public void FindByIdShouldWorkCorrectly()
        {
            int expected= 10;
            Assert.AreEqual (expected,database.FindById(10).Id);
        }
        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        public void FindByIdShouldThrowExceptionWhenIdIsNegative(int id)
        {
            ArgumentOutOfRangeException exception=Assert
                .Throws<ArgumentOutOfRangeException>(()=>database.FindById(id));
            Assert.AreEqual("Id should be a positive number!",exception.ParamName);
        }
        [Test]
        [TestCase(15)]
        [TestCase(232)]
        public void FindByIdThrowsExceptionWhenIdIsNotExistent(int id)
        {
            InvalidOperationException exception = Assert
                .Throws<InvalidOperationException>(() => database.FindById(id));
            Assert.AreEqual("No user is present by this ID!", exception.Message);
        }
    }
        
}
