using ParkingLot.Models.Parking;
using ParkingLot.Models.Payment;
using ParkingLot.Models.Vehicle;
using ParkingLot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Controllers
{
    public class ParkingLotController
    {
        private SlotAllocationService _slotAllocationService;
        private PaymentService _paymentService;
        private TicketGenerationService _ticketGenerationService;
        private List<Ticket> tickets;
        private IPaymentStrategy _paymentStrategy;

        public ParkingLotController(SlotAllocationService slotAllocationService,
        PaymentService paymentService,
        TicketGenerationService ticketGenerationService
        )
        {
            _slotAllocationService = slotAllocationService;
            _paymentService = paymentService;
            _ticketGenerationService = ticketGenerationService;
            tickets = [];
        }

        public int ParkVehicle(Vehicle vehicle)
        {
            var spot = _slotAllocationService.AllocateSpot(vehicle);
            //generate ticket
            var ticket = _ticketGenerationService.GenerateTicket(tickets.Count + 1, vehicle, spot);
            tickets.Add(ticket);
            Console.WriteLine($"{vehicle.VehicleType.ToString()}: {vehicle.LicensePlate} is parked at floor: {ticket.ParkingSpot.FloorNum}, spotnum:{ticket.ParkingSpot.SpotNum}");

            return ticket.Id;
        }

        //get ticketid from printedticket
        public void UnParkVehicle(int ticketId)
        {
            Console.WriteLine("Please choose payment mode:");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. UPI");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    _paymentStrategy = new CreditCardPaymentStrategy();
                    break;
                case 2:
                    _paymentStrategy = new UPIPaymentStrategy();
                    break;
                default:
                    Console.WriteLine("Invalid choice! Defaulting to UPI payment.");
                    _paymentStrategy = new UPIPaymentStrategy();
                    break;
            }
            var ticket = tickets.Find(x => x.Id == ticketId);
            _paymentService.ProcessPayment(_paymentStrategy, ticket);
            Console.WriteLine($"Payment is done, {ticket.ParkedVehicle.VehicleType.ToString()} is unparked");
            _slotAllocationService.FreeSlot(ticket);
        }
    }
}