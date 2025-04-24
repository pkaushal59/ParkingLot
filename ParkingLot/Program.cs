using ParkingLot.Models.Parking;
using ParkingLot.Controllers;
using ParkingLot.Helpers;
using ParkingLot.Services;

Console.WriteLine("   Welcome to the Parking Lot System!   ");
var parkingLot = ParkingLotSpace.GetInstance();
SlotAllocationService slotAllocationService = new(parkingLot);
PaymentService paymentService = new();
TicketGenerationService ticketGenerationService = new();
ParkingLotController parkingLotController =
 new ParkingLotController(slotAllocationService, paymentService, ticketGenerationService);

ParkingLotService parkingLotService = new(parkingLot, 4, 6);

var exit = false;
var ticketId = 0;
while (!exit)
{
    // Display menu
    showMenu();

    // Get user choice
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            // Park a vehicle via the entrance gate
            Console.WriteLine("Enter the vehicle license plate: ");
            var licensePlate = Console.ReadLine();
            Console.WriteLine("Enter the vehicle type (Car or Bike):For Car press 0, Bike 1 ");
            var vehicleType = Convert.ToInt32(Console.ReadLine());
            var vehicle = VehicleFactory.GetVehicle((VehicleType)vehicleType, licensePlate);
            ticketId = parkingLotController.ParkVehicle(vehicle);
            break;

        case 2:
            // Vacate a parking spot via the exit gate
            parkingLotController.UnParkVehicle(ticketId);
            break;

        case 3:
            // Exit the session
            exit = true;
            Console.WriteLine("Thank you for using the Parking Lot System!");
            break;

        default:
            Console.WriteLine("Invalid option! Please try again.");
            break;
    }

}






void showMenu()
{
    Console.WriteLine("\n******************************************************");
    Console.WriteLine("Please choose an option from below:");
    Console.WriteLine("1. Park a vehicle");
    Console.WriteLine("2. Vacate a vehicle spot");
    Console.WriteLine("3. Exit the system");
    Console.WriteLine("******************************************************");
}