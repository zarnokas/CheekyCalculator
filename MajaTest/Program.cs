using System;
using System.Collections.Generic;

namespace MajaTest
{
    class Program
    {
        public static List<IVehicle> Vehicles = new List<IVehicle>();

        public static void Main()
        {
            Vehicles.Add(new Car("123ABC"));
            Vehicles.Add(new Bus("456DEF"));
            Vehicles.Add(new Motorbike("789GHI"));

            DateTime noChargeDate1 = new DateTime(2019, 1, 2, 8, 0, 0); //free day
            DateTime noChargeDate2 = new DateTime(2019, 2, 3, 9, 0, 0); //free day
            DateTime noChargeDate3 = new DateTime(2019, 7, 3, 9, 0, 0); //free day
            DateTime charge1 = new DateTime(2019, 5, 5, 6, 1, 33); // should charge 9
            DateTime charge2 = new DateTime(2019, 5, 5, 6, 35, 44); // should charge 16
            DateTime charge2a = new DateTime(2019, 5, 5, 7, 35, 44); // should charge 16
            DateTime charge2b = new DateTime(2019, 5, 5, 7, 39, 44); // should charge 16
            DateTime charge2c = new DateTime(2019, 5, 5, 9, 35, 44); // should charge 16
            DateTime charge2d = new DateTime(2019, 5, 5, 11, 35, 44); // should charge 16
            DateTime charge2e = new DateTime(2019, 5, 5, 15, 35, 44); // should charge 16
            DateTime charge3 = new DateTime(2019, 5, 7, 7, 11, 55); // should charge 22
            DateTime charge4 = new DateTime(2019, 5, 7, 8, 13, 15); // should charge 16
            DateTime charge5 = new DateTime(2019, 5, 7, 8, 37, 43); // should charge 9
            DateTime charge6 = new DateTime(2019, 5, 8, 10, 23, 44); // should charge 9
            DateTime charge7 = new DateTime(2019, 5, 9, 14, 44, 23); // should charge 9
            DateTime charge8 = new DateTime(2019, 5, 10, 15, 22, 32); // should charge 16
            DateTime charge9 = new DateTime(2019, 5, 11, 16, 25, 42); // should charge 22
            DateTime charge10 = new DateTime(2019, 5, 12, 17, 15, 14); // should charge 16
            DateTime charge11 = new DateTime(2019, 5, 13, 18, 5, 34); // should charge 9
            DateTime charge12 = new DateTime(2019, 5, 14, 6, 6, 6); // should charge 9
            DateTime charge13 = new DateTime(2019, 5, 14, 6, 36, 11); // should charge 16 
            DateTime charge14 = new DateTime(2019, 5, 16, 17, 3, 0); // should charge 16
            DateTime charge15 = new DateTime(2019, 12, 29, 17, 30, 0); // should charge 16


            var tolls = new TollFeeCalculator();

            tolls.ChargeTollFee(charge1, Vehicles[0]);
            tolls.ChargeTollFee(charge2, Vehicles[0]);
            tolls.ChargeTollFee(charge2a, Vehicles[0]);
            tolls.ChargeTollFee(charge2b, Vehicles[0]);
            tolls.ChargeTollFee(charge2c, Vehicles[0]);
            tolls.ChargeTollFee(charge2d, Vehicles[0]);
            tolls.ChargeTollFee(charge2e, Vehicles[0]);
            PrintRecord(Vehicles[0]);
            tolls.ChargeTollFee(charge3, Vehicles[0]);
            PrintRecord(Vehicles[0]);
            tolls.ChargeTollFee(charge4, Vehicles[0]);
            PrintRecord(Vehicles[0]);
            tolls.ChargeTollFee(charge5, Vehicles[0]);
            PrintRecord(Vehicles[0]);
            tolls.ChargeTollFee(charge6, Vehicles[0]);
            PrintRecord(Vehicles[0]);
            tolls.ChargeTollFee(charge7, Vehicles[0]);
            PrintRecord(Vehicles[0]);
            tolls.ChargeTollFee(charge8, Vehicles[0]);
            PrintRecord(Vehicles[0]);
            tolls.ChargeTollFee(charge9, Vehicles[0]);
            PrintRecord(Vehicles[0]);
            tolls.ChargeTollFee(charge10, Vehicles[0]);
            PrintRecord(Vehicles[0]);
            tolls.ChargeTollFee(charge11, Vehicles[0]);
            PrintRecord(Vehicles[0]);
            tolls.ChargeTollFee(charge12, Vehicles[0]);
            PrintRecord(Vehicles[0]);
            tolls.ChargeTollFee(charge13, Vehicles[0]);
            PrintRecord(Vehicles[0]);
            tolls.ChargeTollFee(charge14, Vehicles[0]);
            PrintRecord(Vehicles[0]);
            tolls.ChargeTollFee(charge15, Vehicles[0]);
            
            PrintRecord(Vehicles[0]);

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
            Console.WriteLine($"{vehicle.VehicleType} with plate: {vehicle.VehicleID} has total charge of {vehicle.TotalDailyCharge} with last charge being {vehicle.LastFeeChargeAmount} on {vehicle.LastFeeChargeTime}");
        }
    }
}
