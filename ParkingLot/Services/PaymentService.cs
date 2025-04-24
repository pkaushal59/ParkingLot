using ParkingLot.Models.Parking;
using ParkingLot.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Services
{
    public class PaymentService
    {
        private void CalculateCharge(Ticket ticket)
        {
            var parkedVehicle = ticket.ParkedVehicle;
            ticket.ExiTime = DateTime.Now;
            ticket.Charges = parkedVehicle.Rate * (ticket.ExiTime.Hour - ticket.EntryTime.Hour + 1);
        }
        public void ProcessPayment(IPaymentStrategy strategy, Ticket ticket)
        {
            CalculateCharge(ticket);
            strategy.Pay(ticket.Charges);
            ticket.isPaid = true;
        }
    }
}
