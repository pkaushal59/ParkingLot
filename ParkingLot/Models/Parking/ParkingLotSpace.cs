
namespace ParkingLot.Models.Parking
{
    public class ParkingLotSpace
    {
        private static ParkingLotSpace _instance;
        private static readonly object _lock = new object();
        public List<ParkingFloor> parkingFloors;


        private ParkingLotSpace()
        {
            parkingFloors = [];
        }
        public static ParkingLotSpace GetInstance()
        {
            if (_instance is null)
            {
                lock (_lock)
                {
                    _instance ??= new ParkingLotSpace();
                }
            }

            // GenerateParkingLot(floors, spotsAtEachFloor);
            return _instance;
        }
    }
}
