using System;

namespace MajaTest
{
    class Car : IVehicle
    {
        public Car(string vehicleId)
        {
            VehicleID = vehicleId;
            LastFeeChargeTime = DateTime.MinValue;
            TotalDailyCharge = 0;
        }

        public string VehicleID { get; }

        public VehicleType VehicleType => VehicleType.Car;

        public DateTime LastFeeChargeTime { get; set; }

        public int LastFeeChargeAmount { get; set; }

        public int TotalDailyCharge { get; set; }

        public bool IsTollFree => false;
    }

    class Bus : IVehicle
    {
        public Bus(string vehicleId)
        {
            VehicleID = vehicleId;
            LastFeeChargeTime = DateTime.MinValue;
            TotalDailyCharge = 0;
        }

        public string VehicleID { get; }

        public VehicleType VehicleType => VehicleType.Bus;

        public DateTime LastFeeChargeTime { get; set; }

        public int LastFeeChargeAmount { get; set; }

        public int TotalDailyCharge { get; set; }

        public bool IsTollFree => false;
    }

    class Motorbike : IVehicle
    {
        public Motorbike(string vehicleId)
        {
            VehicleID = vehicleId;
            LastFeeChargeTime = DateTime.MinValue;
            TotalDailyCharge = 0;
        }

        public string VehicleID { get; }

        public VehicleType VehicleType => VehicleType.Motorbike;

        public DateTime LastFeeChargeTime { get; set; }

        public int LastFeeChargeAmount { get; set; }

        public int TotalDailyCharge { get; set; }

        public bool IsTollFree => true;
    }

    class MilitaryVehicle : IVehicle
    {
        public MilitaryVehicle(string vehicleId)
        {
            VehicleID = vehicleId;
            LastFeeChargeTime = DateTime.MinValue;
            TotalDailyCharge = 0;
        }

        public string VehicleID { get; }

        public VehicleType VehicleType => VehicleType.Military;

        public DateTime LastFeeChargeTime { get; set; }

        public int LastFeeChargeAmount { get; set; }

        public int TotalDailyCharge { get; set; }

        public bool IsTollFree => true;
    }

    class EmergencyVehicle : IVehicle
    {
        public EmergencyVehicle(string vehicleId)
        {
            VehicleID = vehicleId;
            LastFeeChargeTime = DateTime.MinValue;
            TotalDailyCharge = 0;
        }

        public string VehicleID { get; }

        public VehicleType VehicleType => VehicleType.Emergency;

        public DateTime LastFeeChargeTime { get; set; }

        public int LastFeeChargeAmount { get; set; }

        public int TotalDailyCharge { get; set; }

        public bool IsTollFree => true;
    }


    class Truck : IVehicle
    {
        public Truck(string vehicleId)
        {
            VehicleID = vehicleId;
            LastFeeChargeTime = DateTime.MinValue;
            TotalDailyCharge = 0;
        }

        public string VehicleID { get; }

        public VehicleType VehicleType => VehicleType.Truck;

        public DateTime LastFeeChargeTime { get; set; }

        public int LastFeeChargeAmount { get; set; }

        public int TotalDailyCharge { get; set; }

        public bool IsTollFree => false;
    }
}
