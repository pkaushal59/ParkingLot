using ParkingLot.Helpers;
using ParkingLot.Models.Parking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Services
{
    public class ParkingLotService
    {
        private List<ParkingFloor> parkingFloors;

        public ParkingLotService(ParkingLotSpace parkingLot, int floors, int spotsAtEachFloor)
        {
            parkingFloors = [];
            var carSpots = (int)(0.5 * spotsAtEachFloor);
            var bikeSpots = (int)(0.4 * spotsAtEachFloor);

            for (var i = 0; i < floors; i++)
            {
                var floor = new ParkingFloor();
                floor.FloorNum = i;
                for (int j = 0; j < carSpots; j++)
                {
                    var slot = new ParkingSpot
                    {
                        AllowedVehicleType = VehicleType.Car,
                        SpotNum = j,
                        FloorNum = i
                    };
                    floor.spots.Add(slot);
                }

                for (int j = carSpots; j < bikeSpots + carSpots; j++)
                {
                    var slot = new ParkingSpot
                    {
                        AllowedVehicleType = VehicleType.Bike,
                        SpotNum = j,
                        FloorNum = i
                    };
                    floor.spots.Add(slot);
                }

                for (int j = carSpots + bikeSpots; j < spotsAtEachFloor; j++)
                {
                    var slot = new ParkingSpot
                    {
                        AllowedVehicleType = VehicleType.Others,
                        SpotNum = j,
                        FloorNum = i
                    };
                    floor.spots.Add(slot);
                }
                parkingFloors.Add(floor);
            }

            parkingLot.parkingFloors = parkingFloors;
        }
    }
}
