using NUnit.Framework;
using System;

namespace RentalCar.Tests
{
    [TestFixture]
    public class RentalCarTests
    {
        private RentalCar _car;

        [SetUp]
        public void Setup()
        {
            _car = new RentalCar("Toyota", "Camry", "Saloon", "ABC123", 50.0, false);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual("Toyota", _car.Manufacturer);
            Assert.AreEqual("Camry", _car.Model);
            Assert.AreEqual("Saloon", _car.BodyType);
            Assert.AreEqual("ABC123", _car.RegistrationNumber);
            Assert.AreEqual(50.0, _car.Price);
            Assert.IsFalse(_car.CheckBorrowed());
        }

        [Test]
        public void TestBorrow()
        {
            _car.Borrow();
            Assert.IsTrue(_car.CheckBorrowed());
            
            // Try to borrow again
            _car.Borrow();
            Assert.IsTrue(_car.CheckBorrowed());
        }

        [Test]
        public void TestReturnRentalCar()
        {
            _car.Borrow();
            _car.ReturnRentalCar();
            Assert.IsFalse(_car.CheckBorrowed());
        }

        [Test]
        public void TestChangePrice()
        {
            _car.ChangePrice(60.0);
            Assert.AreEqual(60.0, _car.CheckPrice());
        }

        [Test]
        public void TestCheckPrice()
        {
            Assert.AreEqual(50.0, _car.CheckPrice());
        }

        [Test]
        public void TestCheckBorrowed()
        {
            Assert.IsFalse(_car.CheckBorrowed());
            _car.Borrow();
            Assert.IsTrue(_car.CheckBorrowed());
        }

        [Test]
        public void TestInvalidBodyType()
        {
            Assert.Throws<ArgumentException>(() => 
                new RentalCar("Toyota", "Camry", "Invalid", "ABC123", 50.0, false));
        }

        [Test]
        public void TestNegativePrice()
        {
            Assert.Throws<ArgumentException>(() => _car.ChangePrice(-10.0));
        }

        [Test]
        public void TestNullManufacturer()
        {
            Assert.Throws<ArgumentException>(() => 
                new RentalCar(null, "Camry", "Saloon", "ABC123", 50.0, false));
        }
    }
}