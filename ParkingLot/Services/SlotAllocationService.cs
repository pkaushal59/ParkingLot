using ParkingLot.Models.Parking;
using ParkingLot.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Services
{
    public class SlotAllocationService
    {
        private ParkingLotSpace _parkingLot;

        public SlotAllocationService(ParkingLotSpace parkingLot)
        {
            _parkingLot = parkingLot;
        }


        public ParkingSpot AllocateSpot(Vehicle vehicle)
        {
            foreach (var floor in _parkingLot.parkingFloors)
            {
                var availableSlot = floor.spots.FirstOrDefault(x => CanParkVehicle(vehicle, x));
                if (availableSlot != null)
                {
                    availableSlot.ParkedVehicle = vehicle;
                    availableSlot.isOccupied = true;
                    return availableSlot;
                }
            }

            throw new Exception("No available slots for this vehicle type.");
        }
        public void FreeSlot(Ticket ticket)
        {
            var floor = _parkingLot.parkingFloors.FirstOrDefault(x => x.FloorNum == ticket.ParkingSpot.FloorNum);
            if (floor != null)
            {
                var spot = floor.spots.FirstOrDefault(x => x.SpotNum == ticket.ParkingSpot.SpotNum);
                if (spot != null)
                {
                    spot.ParkedVehicle = null;
                    spot.isOccupied = false;
                }
            }
        }

        private bool CanParkVehicle(Vehicle vehicle, ParkingSpot spot)
        {
            if (!vehicle.VehicleType.Equals(spot.AllowedVehicleType)) return false;
            return !spot.isOccupied;
        }
    }
}
