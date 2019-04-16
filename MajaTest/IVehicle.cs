using System;

namespace MajaTest
{
    //Vehicle interface that all vehicles have to inherit
    public interface IVehicle
    {
        //VehicleID that should ideally be its license plate
        string VehicleID { get; }

        //Vehicle type that is defined by VehicleType enum
        VehicleType VehicleType { get; }

        //Timestamp of the last charge for the vehicle
        DateTime LastFeeChargeTime { get; set; }

        //Amount of the last charge for the vehicle
        int LastFeeChargeAmount { get; set; }

        //Current total charge for the day
        int TotalDailyCharge { get; set; }

        //Boolean flag for fee exemption
        bool IsTollFree { get; }

    }

    //Define all possible vehicle types
    public enum VehicleType
    {
        Car = 0,
        Bus = 1,
        Motorbike = 2,
        Emergency = 3,
        Military = 4,
        Truck = 5
    }
}
