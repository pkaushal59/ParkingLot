using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models.Parking
{
    public class ParkingFloor
    {
        public int FloorNum { get; set; }
        public List<ParkingSpot> spots { get; set; } = new List<ParkingSpot>();
    }
}
