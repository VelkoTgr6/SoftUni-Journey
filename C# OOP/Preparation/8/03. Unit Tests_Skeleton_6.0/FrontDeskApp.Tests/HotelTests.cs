using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Threading;
using System.Xml.Linq;

namespace BookigApp.Tests
{
    public class Tests
    {
        Hotel hotel;
        Room room;
        [SetUp]
        public void Setup()
        {
            var hotel = new Hotel("Asa", 5);
            var room = new Room(2, 10);
        }

        [Test]
        public void IsHotelCtorSettingCorrectly()
        {
            var hotel = new Hotel("Asa", 5);
            string expectedName = "Asa";
            int expectedCategory = 5;
            double expectedTurnouver = 0;

            Assert.AreEqual(expectedName, hotel.FullName);
            Assert.AreEqual(expectedCategory, hotel.Category);
            Assert.AreEqual(expectedTurnouver, hotel.Turnover);
        }
        [TestCase(null)]
        [TestCase(" ")]
        public void HotelNameThrowsExceptionWhenNullOrWhitespace(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(name, 5));
            
        }
        [TestCase(7)]
        [TestCase(0)]
        public void HotelCategoryShouldThrowExceptionWhenCategoryIsNotBetween1and5(int category)
        {
            Assert.Throws<ArgumentException>(() => new Hotel("Asa", category));
        }
        [Test]
        public void AddRoomWorksCorrectly()
        {
            var hotel = new Hotel("bb", 5);
            var room=new Room(2,10);
            hotel.AddRoom(room);
            Assert.AreEqual(1,hotel.Rooms.Count);
        }
        [TestCase(0)]
        [TestCase(-1)]
        public void BookRoomThrowsExceptionWhenAdultsAreLessOr0(int adults)
        {
            var hotel = new Hotel("Asa", 5);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(adults,1,20,300));
        }
        
        [TestCase(-1)]
        public void BookRoomThrowsExceptionWhenChildersAreLessThan0(int childern)
        {
            var hotel = new Hotel("Asa", 5);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, childern, 20, 300));
        }
        [TestCase(-1)]
        [TestCase(0)]
        public void BookRoomThrowsExceptionWhenWhenDurationISLessThan1(int duration)
        {
            var hotel = new Hotel("Asa", 5);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, 2, duration, 300));
        }
        [Test]
        public void BookRoom_notBookingWhenBedsNeededAreMore()
        {
            var hotel = new Hotel("Asa", 5);
            var room = new Room(2, 400);

            hotel.BookRoom(2, 2, 2, 500);
            Assert.AreEqual(0,hotel.Bookings.Count);
        }
        [Test]
        public void BookRoomWorkCorrectly()
        {
            var hotel = new Hotel("Asa", 5);
            var room = new Room(2, 200);
            hotel.AddRoom(room);

            hotel.BookRoom(2, 0, 2, 500);
            double expectedTurnover = 400;
            Assert.AreEqual(1,hotel.Bookings.Count);
            Assert.AreEqual(1, hotel.Rooms.Count);
            Assert.AreEqual(expectedTurnover, hotel.Turnover);
        }
        [Test]
        public void BookRoomNotBookingWhenLowBudget()
        {
            var hotel = new Hotel("Asa", 5);
            var room = new Room(2, 200);
            hotel.AddRoom(room);

            hotel.BookRoom(1,2,1,50);
            Assert.AreEqual(0, hotel.Bookings.Count);
            Assert.AreEqual(0, hotel.Turnover);
        }





    }
}