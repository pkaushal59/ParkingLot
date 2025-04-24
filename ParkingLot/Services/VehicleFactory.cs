using ParkingLot.Helpers;
using ParkingLot.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Services
{
    public class VehicleFactory
    {
        public static Vehicle GetVehicle(VehicleType type, string licensePlate)
        {
            return type switch
            {
                VehicleType.Car => new Car(licensePlate),
                VehicleType.Bike => new Bike(licensePlate),
                VehicleType.Others => new Others(licensePlate),
                _ => throw new InvalidDataException()
            };
        }
    }
}
