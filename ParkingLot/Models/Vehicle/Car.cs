using ParkingLot.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ParkingLot.Models.Vehicle
{
    public class Car : Vehicle
    {
        public Car(string licensePlate)
        {
            LicensePlate = licensePlate;
            VehicleType = VehicleType.Car;
            Rate = 20;
        }
    }
}
