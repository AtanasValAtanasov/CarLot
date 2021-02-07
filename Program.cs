using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarListApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Inventory inventory = new Inventory();
            int action = -1;
            addCars(inventory);

            Console.WriteLine("Chose action to continue.");
            
            while (action == -1 || action > 5)
            {
                action = chooseAction();
            }
            while (action != 5 && action <= 5 && action >= 0)
            {
                Console.WriteLine("You chose " + action + ".");

                switch (action)
                {
                    case 0:
                        Console.WriteLine("The cars in the inventory are:");
                        checkInventory(inventory);
                        break;

                    case 1:
                        Console.WriteLine("You chose to add a new car to the car list.");
                        String carMaker = "";
                        String carModel = "";
                        String carHorsePower = "";
                        String carColor = "";
                        String carFuelType = "";
                        String checkPrice = "";
                        decimal carPrice = 0.0M;
                        Console.WriteLine("What is the car maker?");
                        carMaker = Console.ReadLine();
                        Console.WriteLine("What is the car model?");
                        carModel = Console.ReadLine();
                        Console.WriteLine("How much horsepower does the car have?");
                        carHorsePower = Console.ReadLine();
                        Console.WriteLine("What is the car color?");
                        carColor = Console.ReadLine();
                        Console.WriteLine("What is the car fuel type?");
                        carFuelType = Console.ReadLine();
                        Console.WriteLine("What is the car price?");
                        checkPrice = Console.ReadLine();
                        try
                        {
                            carPrice =decimal.Parse(checkPrice);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Wrong value input.");
                            break;
                        }
                        Car newCar = new Car(carMaker, carModel, carHorsePower, carColor, carFuelType, carPrice);
                        inventory.CarList.Add(newCar);
                        Console.WriteLine(newCar + " Has been added to the car list.");
                        break;


                    case 2:
                        Console.WriteLine("Chose a car from the list of the carlot to be removed.");
                        checkInventory(inventory);
                        Console.WriteLine("Which car would you like to remove?#N");
                        int carRemove = int.Parse(Console.ReadLine());
                        if (inventory.CarList.Count > 1)
                        {
                            inventory.CarList.Remove(inventory.CarList[carRemove]);
                        }
                        else
                        {
                            Console.WriteLine("No more cars left to remove!");
                        }
                        checkInventory(inventory);
                        break;

                    case 3:
                        Console.WriteLine("Chose a car from the list of the carlot.");
                        checkInventory(inventory);
                        Console.WriteLine("Which car would you like to buy?#N");
                        int carChosen = int.Parse(Console.ReadLine());
                        inventory.BuyingList.Add(inventory.CarList[carChosen]);
                        inventory.CarList.Remove(inventory.CarList[carChosen]);
                        checkBuyingList(inventory);
                        break;

                    case 4:
                        checkBuyingList(inventory);
                        Console.WriteLine("The price for the cars you have selected is:" + inventory.Checkout() + "$.");
                        break;

                    case 5:
                        break;

                }
                action = chooseAction();
                while (action == -1 || action>5)
                {
                    action = chooseAction();
                }
            }
        }

        private static void addCars(Inventory inventory)
        {
            Car vehicleone = new Car();
            inventory.CarList.Add(vehicleone);
            Car vehicletwo = new Car("Chevy", "Camaro", "700", "Black", "Gas", 152999.99M);
            inventory.CarList.Add(vehicletwo);
            Car vehiclethree = new Car("Honda", "Civic", "101", "Green", "Electric", 35432.23M);
            inventory.CarList.Add(vehiclethree);
            Car vehiclefour = new Car("Dodge", "Charger", "801", "Yellow", "Diesel", 75834.82M);
            inventory.CarList.Add(vehiclefour);
            Car vehiclefive = new Car("Toyota", "Supra", "372", "Lemon", "Gas", 315243.23M);
            inventory.CarList.Add(vehiclefive);
            Car vehiclesix = new Car("Toyota", "Corolla", "136", "Red", "Gas", 21030.23M);
            inventory.CarList.Add(vehiclesix);
            Car vehicleseven = new Car("Chevy", "Impala", "250", "White", "Diesel", 25348.18M);
            inventory.CarList.Add(vehicleseven);
            Car vehicleeight = new Car("Honda", "Jazz", "34", "Pink", "Gas", 3530.18M);
            inventory.CarList.Add(vehicleeight);
            Car vehiclenine= new Car("Dodge", "Viper", "1001", "Yellow", "Gas", 750300.99M);
            inventory.CarList.Add(vehiclenine);
            Car vehicleten = new Car("Toyota", "Rav4", "215", "Black", "Diesel", 10230.99M);
            inventory.CarList.Add(vehicleten);
        }

        private static void checkInventory(Inventory inventory)
        {
            
            for (int i = 0; i < inventory.CarList.Count; i++)
            {
                Console.WriteLine("Car:"+i+" "+inventory.CarList[i]);
           
            }
        }

        private static void checkBuyingList(Inventory inventory)
        {
            Console.WriteLine("Car/s chosen to be bought.");
            for (int i = 0; i < inventory.BuyingList.Count; i++)
            {
                Console.WriteLine("Car #" + i + " " + inventory.CarList[i]);

            }
        }


        static public int chooseAction()
        {
            string choice = "";
            int chosen = 0;
            Console.WriteLine("Enter (0) to check the list of cars, (1) to add a new car, (2) to remove a car from the Inventory, (3) to open buying list , (4) to check your total from the shopping list and (5) to quit.");
            choice = Console.ReadLine();
            try
            {
               chosen = int.Parse(choice);
                if (chosen >= 0 && chosen <= 5)
                {
                    return chosen;
                }
                else
                {
                    Console.WriteLine("Chose again,wrong input!");
                    Console.WriteLine("Enter (0) to check the list of cars, (1) to add a new car, (2) to remove a car from the Inventory, (3) to open buying list , (4) to check your total from the shopping list and (5) to quit.");
                    choice = (Console.ReadLine());
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Chose again,wrong input!");
                return -1;
            }
            return chosen;
        }
    }

    public class Inventory
    {
        public List<Car> CarList { get; set; }
        public List<Car> BuyingList { get; set; }

        public Inventory()
        {
            CarList = new List<Car>();
            BuyingList = new List<Car>();
        }
        public  decimal Checkout()
        {
            decimal Cost = 0.0M;
            foreach (var car in BuyingList)
            {
                Cost = Cost + car.Price;
            }
            BuyingList.Clear();
            return Cost;
        }

    }
    public class Car
    {
        public string Maker { get; set; }
        public string Model { get; set; }
        public string Horsepower { get; set; }
        public string Color { get; set; }
        public string FuelType { get; set; }
        public decimal Price { get; set; }

        public Car()
        {
            Maker = "Ford";
            Model = "F150";
            Horsepower = "350";
            Color = "Red";
            FuelType = "Diesel";
            Price = 50000.0M;
        }

        public Car(string maker, string model,string horsepower, string color, string fueltype, decimal price)
        {
            Maker = maker;
            Model = model;
            Horsepower = horsepower;
            Color = color;
            FuelType = fueltype;
            Price = price;
        }

        override public string ToString()
        {
            return "Maker:" + Maker + ",Model:" + Model + ",Horsepower:" + Horsepower+ ",Color:" + Color + ",FuelType:" + FuelType + ",Price:" + Price + "$.";
        }
    }
}
