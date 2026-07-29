namespace Television.Tests
{
    using System;
    using System.Diagnostics;
    using System.Numerics;
    using System.Xml.Linq;
    using NUnit.Framework;
    public class Tests
    {
        private TelevisionDevice device;
        [SetUp]
        public void Setup()
        {
            device = new TelevisionDevice("samsung", 200, 20, 10);
            
        }

        [Test]
        public void IsConstrucorSettingProperly() 
        {
            string expectedName = "samsung";
            double expectedPrice = 200;
            double expectedWidth = 20;
            double expectedHeight = 10;

            Assert.AreEqual(expectedName, device.Brand);
            Assert.AreEqual(expectedPrice, device.Price);
            Assert.AreEqual(expectedWidth, device.ScreenWidth);
            Assert.AreEqual(expectedHeight, device.ScreenHeigth);
        }
        [Test]
        public void ChangeChannelShouldWorkProperly()
        {
            device.ChangeChannel(5);
            Assert.AreEqual(5, device.CurrentChannel);
        }
        [Test]
        public void ChangeChannelShouldThrowExceptionWhenNegative()
        {
            ArgumentException exception = Assert
                .Throws<ArgumentException>(() => device.ChangeChannel(-5));
            Assert.AreEqual("Invalid key!", exception.Message);
        }
        [Test]
        public void VolumeChangeShouldWorkCorrectly()
        {
            var expectedUnit = Math.Abs(33);

            Assert.AreEqual($"Volume: {expectedUnit}", device.VolumeChange("UP", 20));
            Assert.AreEqual(expectedUnit, device.Volume);
        }
        [Test]
        public void VolumeChangeWhenUPAndValueIsMoreThan100ShouldReturn100()
        {
            var expectedUnit = Math.Abs(100);

            Assert.AreEqual($"Volume: {expectedUnit}", device.VolumeChange("UP", 120));
        }
        [Test]
        public void VolumeChangeWhenDOWNAndValueIsNegativeShouldReturn()
        {
            var expectedUnit = Math.Abs(0);

            Assert.AreEqual($"Volume: {expectedUnit}", device.VolumeChange("DOWN", -120));
        }
        [Test]
        public void IsMutedShouldWorkCorrectly()
        {
            Assert.IsTrue(device.MuteDevice());
            Assert.IsTrue(device.IsMuted);
        }
        [Test]
        public void SwitchOnShouldWorkCorrectly()
        {
            device.ChangeChannel(3);
            var expectedChannel= 3;
            var expectedvoume = 13;
            var expectedMute = "On";
            Assert.AreEqual($"Cahnnel {expectedChannel} - Volume {expectedvoume} - Sound {expectedMute}"
                ,device.SwitchOn());
        }
        [Test]
        public void ToStringShouldWorkCorrectly()
        {
            Assert.AreEqual(device.ToString()
                , $"TV Device: {device.Brand}, Screen Resolution: {device.ScreenWidth}x{device.ScreenHeigth}, Price {device.Price}$") 
                ;
        }
    }
}