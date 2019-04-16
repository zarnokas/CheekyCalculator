using System;
using System.Collections.Generic;
using System.Threading;

namespace MajaTest
{
    class Program
    {
        public static List<IVehicle> Vehicles = new List<IVehicle>();
        private static Random randomGenerator = new Random();

        public static void Main()
        {
            //Add some vehicles to the list
            Vehicles.Add(new Car("123ABC"));
            Vehicles.Add(new Bus("456DEF"));
            Vehicles.Add(new Motorbike("789GHI"));
            Vehicles.Add(new EmergencyVehicle("ABC123"));
            Vehicles.Add(new Truck("DEF456"));
            Vehicles.Add(new MilitaryVehicle("GHI789"));

            RunSimulation(100, true);
        }

        public static void RunSimulation(int simulationIterations, bool slowDown = false, int delay = 100)
        {
            //initialise our Toll Fee Calculator
            var tolls = new TollFeeCalculator();
            var simulationTime = DateTime.Today;

            while (simulationIterations > 0)
            {
                //start generating random times
                simulationTime = GenerateRandomDate(simulationTime);
                //Pick random vehicle from the list and charge it
                tolls.ChargeTollFee(simulationTime, Vehicles[randomGenerator.Next(Vehicles.Count)]);
                //decrement simulation counter
                simulationIterations--;
                if (slowDown)
                {
                    Thread.Sleep(delay);

                }
            }
        }

        public static DateTime GenerateRandomDate(DateTime startDate)
        {
            DateTime randomTime = new DateTime(startDate.Year, 
                                                startDate.Month,
                                                startDate.Day, 
                                                startDate.AddHours(randomGenerator.Next(2)).Hour, 
                                                startDate.AddMinutes(randomGenerator.Next(60)).Minute, 
                                                startDate.AddSeconds(randomGenerator.Next(60)).Second);

            //since we don't want to end up in a same day loop increment to the next day when applicable
            if (startDate > randomTime)
            {
                return randomTime.AddDays(1);
            }

            return randomTime;
        }

        public static void PrintRecords()
        {
            foreach (var vehicle in Vehicles)
            {
                PrintRecord(vehicle);
            }
        }

        public static void PrintRecord(IVehicle vehicle)
        {
            Console.WriteLine($"{vehicle.VehicleType} with plate: {vehicle.VehicleID} has total charge of {vehicle.TotalDailyCharge}");
        }
    }
}
