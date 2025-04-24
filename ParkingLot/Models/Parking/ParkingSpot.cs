using ParkingLot.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models.Parking
{
    public class ParkingSpot
    {
        public int SpotNum { get; set; }
        public Vehicle.Vehicle ParkedVehicle { get; set; }
        public bool isOccupied { get; set; }
        public VehicleType AllowedVehicleType { get; set; }
        public int FloorNum { get; set; }

    }
}
