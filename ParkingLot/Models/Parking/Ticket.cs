using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models.Parking
{
    public class Ticket
    {
        public int Id { get; set; }
        public Vehicle.Vehicle ParkedVehicle { get; set; }
        public ParkingSpot ParkingSpot { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExiTime { get; set; }
        public double Charges { get; set; }
        public bool isPaid { get; set; }
    }
}
