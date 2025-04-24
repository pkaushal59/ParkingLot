using ParkingLot.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ParkingLot.Models.Vehicle
{
    public class Others : Vehicle
    {
        public Others(string licensePlate)
        {
            LicensePlate = licensePlate;
            VehicleType = VehicleType.Others;
            Rate = 50;
        }
    }
}
