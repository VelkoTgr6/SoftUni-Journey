namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public class Tests
    {
        Device device;
        [SetUp]
        public void Setup()
        {
            device = new(4000);  
        }

        [Test]
        public void DeviceConstructorShouldSetCorrectly()
        {
            int expectedMemoryCapacity = 4000;
           // int expectedAvailableCapacity = 3900;
           // int expectedPhotos = 0;
           // int expectedApplications = 0;
                

            Assert.AreEqual(expectedMemoryCapacity, device.MemoryCapacity);
        }
        [TestCase(500)]
        [TestCase(1000)]
        public void TakePhotoShouldWorkCorrectly(int size)
        {
            Assert.AreEqual(true,device.TakePhoto(size));
        }
        [TestCase(50)]
        [TestCase(500)]
        public void TakePhotosShouldReduceAvailableMemory(int size)
        {
            device.TakePhoto(size);
            int expectedAvailableCapacity = device.MemoryCapacity-size;
            Assert.AreEqual(expectedAvailableCapacity,device.AvailableMemory);
        }
        [Test]
        public void TakePhotosShouldAddPhotosToList()
        {
            device.TakePhoto(50);
            device.TakePhoto(100);
            Assert.AreEqual(2, device.Photos);
        }
        [TestCase(5000)]
        [TestCase(4001)]
        public void TakePhotoShouldReturnFalseWhenSizeIsMoreThanAvailableMemory(int size)
        {
            Assert.AreEqual(false,device.TakePhoto(size));
        }
        [Test]
        public void InstallAppShouldWorkCorrectly()
        {
            string appName = "snake";
            int appSize= 100;
            Assert.AreEqual($"{appName} is installed successfully. Run application?", device.InstallApp(appName, appSize));
        }
        [Test]
        public void InstallAppShouldReduceAvailableMemoryFromTheAppSize()
        {
            string appName = "snake";
            int appSize = 100;
            int expectedAvailableMemory = 3900;
            device.InstallApp(appName, appSize);
            Assert.AreEqual(expectedAvailableMemory, device.AvailableMemory);
        }
        [Test]
        public void InstallAppShouldAddAppsNamesToList()
        {
            List<string> applications = new List<string>();
            string appName = "snake";
            int appSize = 100;
            applications.Add(appName);
            device.InstallApp(appName, appSize);
            Assert.AreEqual(applications.Count,device.Applications.Count);
        }
        [Test]
        public void InstallAppShouldThrowExceptionWhenInstallingAppWhitBiggerSizeThanAvailableMemory()
        {
            InvalidOperationException exception = Assert
                .Throws<InvalidOperationException>(() => device.InstallApp("snake", 5000));
            Assert.AreEqual("Not enough available memory to install the app.",exception.Message);
        }
        [Test]
        public void FormatDeviceShouldMakePhotosCount0()
        {
            device.TakePhoto(100);
            device.TakePhoto(20);
            device.TakePhoto(30);
            device.FormatDevice();
            int expectedPhotoCount=0;
            Assert.AreEqual(0, device.Photos);
        }
        [Test]
        public void FormatDeviceShouldCreateNewListOfApps()
        {
            List<string> applications = new List<string>() { "snake", "super mario", "tmnt" };
            device.FormatDevice();
            Assert.AreEqual(0, device.Applications.Count);
        }
        [Test]
        public void FormatDataShouldResetAvailableMememoryCapacityWithDefaultMemmoryCapacity()
        {
            device.TakePhoto(1000);
            device.FormatDevice();
            Assert.AreEqual(device.MemoryCapacity, device.AvailableMemory);
        }
        [Test]
        public void GetDeviceStatusShouldWorkCorrectly()
        {
            device.TakePhoto(1000);
            device.InstallApp("snake", 500);
            device.InstallApp("lol", 500);
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Memory Capacity: {device.MemoryCapacity} MB, Available Memory: {2000} MB");
            stringBuilder.AppendLine($"Photos Count: {1}");
            stringBuilder.AppendLine($"Applications Installed: {string.Join(", ", device.Applications)}");

            Assert.AreEqual(stringBuilder.ToString().TrimEnd(),device.GetDeviceStatus());
        }
    }
}