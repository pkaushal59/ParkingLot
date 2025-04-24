using ParkingLot.Models.Parking;
using ParkingLot.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Services
{
    public class TicketGenerationService
    {
        public Ticket GenerateTicket(int id, Vehicle vehicle, ParkingSpot spot)
        {
            var ticket = new Ticket();
            ticket.Id = id;
            ticket.ParkedVehicle = vehicle;
            ticket.ParkingSpot = spot;
            ticket.EntryTime = DateTime.Now;
            return ticket;
        }
    }
}
