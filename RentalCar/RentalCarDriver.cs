using System;

namespace RentalCar
{
    public class RentalCarDriver
    {
        public static void Run()
        {
            // Create at least 4 RentalCar objects
            var car1 = new RentalCar("Toyota", "Camry", "Saloon", "ABC123", 50.0, false);
            var car2 = new RentalCar("Honda", "Civic", "HatchBack", "DEF456", 45.0);
            var car3 = new RentalCar("Ford", "Mustang", "Convertible");
            var car4 = new RentalCar("Nissan", "Qashqai", "CrossOver", "GHI789", 55.0, true);

            // Display details of all cars
            Console.WriteLine("Initial car details:");
            car1.Display();
            car2.Display();
            car3.Display();
            car4.Display();

            // Demonstrate all methods for each car
            DemonstrateMethods(car1);
            DemonstrateMethods(car2);
            DemonstrateMethods(car3);
            DemonstrateMethods(car4);
        }

        private static void DemonstrateMethods(RentalCar car)
        {
            Console.WriteLine($"Demonstrating methods for {car.Manufacturer} {car.Model}");
            
            // Borrow()
            Console.WriteLine("Attempting to borrow the car:");
            car.Borrow();
            Console.WriteLine($"Borrowed status: {car.CheckBorrowed()}");

            // ReturnRentalCar()
            Console.WriteLine("Returning the car:");
            car.ReturnRentalCar();
            Console.WriteLine($"Borrowed status: {car.CheckBorrowed()}");

            // ChangePrice()
            Console.WriteLine("Changing price to $60.0:");
            car.ChangePrice(60.0);

            // CheckPrice()
            Console.WriteLine($"Current price: ${car.CheckPrice()}");

            // CheckBorrowed()
            Console.WriteLine($"Current borrowed status: {car.CheckBorrowed()}");

            // Display()
            Console.WriteLine("Updated car details:");
            car.Display();

            Console.WriteLine("--------------------");
        }
    }
}