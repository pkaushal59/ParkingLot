using ParkingLot.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models.Vehicle
{
    public abstract class Vehicle
    {
        public string LicensePlate { get; set; }
        public VehicleType VehicleType { get; set; }

        public double Rate { get; set; }
    }
}
