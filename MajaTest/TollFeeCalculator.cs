using System;

namespace MajaTest
{
    public class TollFeeCalculator
    {
        public void ChargeTollFee(IVehicle vehicle)
        {
            if (!vehicle.IsTollFree)
            {
                ApplyFee(DateTime.Now, vehicle);
            }
        }
        
        public void ChargeTollFee(DateTime time, IVehicle vehicle)
        {
            if (!vehicle.IsTollFree)
            {
                ApplyFee(time, vehicle);
            }
            else
            {
                Console.WriteLine($"{vehicle.VehicleType} is toll free!!!");
            }
        }


        public void ApplyFee(DateTime date, IVehicle vehicle)
        {
            var timeDiff = date - vehicle.LastFeeChargeTime;

            //reset daily fee if needed
            ResetDailyFee(vehicle, date);

            //if we pass toll station within an hour update price if needed
            if (timeDiff.TotalMinutes < 60 && timeDiff.Hours < 1)
            {
                var feeCharge = TollFee.GetFee(date);

                if (feeCharge > vehicle.LastFeeChargeAmount)
                {
                    //if charge is greater than the last one, update it
                    vehicle.TotalDailyCharge = vehicle.TotalDailyCharge - vehicle.LastFeeChargeAmount + feeCharge;
                    vehicle.LastFeeChargeAmount = feeCharge;

                    //In case you want to get some feedback
                    Console.WriteLine($"{date}: Updated {vehicle.VehicleType} {vehicle.VehicleID} with new charging fee of {feeCharge}");
                }
                else
                {
                    //In case you want to get some feedback
                    Console.WriteLine($"{date}: No additional charge for {vehicle.VehicleType} {vehicle.VehicleID}. Time diff {timeDiff} between {date} and {vehicle.LastFeeChargeTime}");
                }
            }
            else
            {
                //Slap on that additional charge and update records
                vehicle.LastFeeChargeAmount = TollFee.GetFee(date);
                vehicle.TotalDailyCharge += vehicle.LastFeeChargeAmount;
                vehicle.LastFeeChargeTime = date;

                //check if we maxed out daily charge and cap it if necessary
                if (vehicle.TotalDailyCharge > 60)
                {
                    vehicle.TotalDailyCharge = 60;
                }

                //In case you want to get some feedback
                Console.WriteLine($"{date}: Charged  {vehicle.VehicleType} {vehicle.VehicleID} with a fee of {vehicle.LastFeeChargeAmount}");
            }
        }

        public void ResetDailyFee(IVehicle vehicle, DateTime date)
        {
            if (date.Day != vehicle.LastFeeChargeTime.Day)
            {
                vehicle.TotalDailyCharge = 0;
                vehicle.LastFeeChargeAmount = 0;
                vehicle.LastFeeChargeTime = DateTime.Today;
            }
        }
    }
}
