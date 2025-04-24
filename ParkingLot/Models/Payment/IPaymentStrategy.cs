﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models.Payment
{
    public interface IPaymentStrategy
    {
        public void Pay(double amount);
    }
}
