using System;
using System.Collections.Generic;

namespace RentalCar
{
    public class RentalCar
    {
        public string Manufacturer { get; private set; }
        public string Model { get; private set; }
        public string BodyType { get; private set; }
        public string RegistrationNumber { get; private set; }
        public double Price { get; private set; }
        public bool Borrowed { get; private set; }

        private static readonly List<string> ValidBodyTypes = new List<string>
        {
            "Saloon", "HatchBack", "Convertible", "CrossOver", "MPV"
        };

        public RentalCar(string manufacturer, string model, string bodyType, 
                         string registrationNumber, double price, bool borrowed)
        {
            SetManufacturer(manufacturer);
            SetModel(model);
            SetBodyType(bodyType);
            SetRegistrationNumber(registrationNumber);
            SetPrice(price);
            Borrowed = borrowed;
        }

        public RentalCar(string manufacturer, string model, string bodyType, 
                         string registrationNumber, double price)
            : this(manufacturer, model, bodyType, registrationNumber, price, false)
        {
        }

        public RentalCar(string manufacturer, string model, string bodyType)
            : this(manufacturer, model, bodyType, "Unregistered", 0.0, false)
        {
        }

        private void SetManufacturer(string manufacturer)
        {
            if (string.IsNullOrWhiteSpace(manufacturer))
                throw new ArgumentException("Manufacturer cannot be null or empty");
            Manufacturer = manufacturer;
        }

        private void SetModel(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Model cannot be null or empty");
            Model = model;
        }

        private void SetBodyType(string bodyType)
        {
            if (!ValidBodyTypes.Contains(bodyType))
                throw new ArgumentException("Invalid body type");
            BodyType = bodyType;
        }

        private void SetRegistrationNumber(string registrationNumber)
        {
            if (string.IsNullOrWhiteSpace(registrationNumber))
                throw new ArgumentException("Registration number cannot be null or empty");
            RegistrationNumber = registrationNumber;
        }

        private void SetPrice(double price)
        {
            if (price < 0)
                throw new ArgumentException("Price cannot be negative");
            Price = price;
        }

        public void Borrow()
        {
            if (Borrowed)
            {
                Console.WriteLine("Error: This RentalCar is already on loan.");
            }
            else
            {
                Borrowed = true;
            }
        }

        public void ReturnRentalCar()
        {
            Borrowed = false;
        }

        public void ChangePrice(double price)
        {
            SetPrice(price);
        }

        public double CheckPrice()
        {
            return Price;
        }

        public bool CheckBorrowed()
        {
            return Borrowed;
        }

        public void Display()
        {
            Console.WriteLine("*************************");
            Console.WriteLine($"Manufacturer: {Manufacturer}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Body Type: {BodyType}");
            Console.WriteLine($"Registration Number: {RegistrationNumber}");
            Console.WriteLine($"Price: ${Price:F2}");
            Console.WriteLine($"Borrowed: {Borrowed}");
            Console.WriteLine();
        }
    }
}