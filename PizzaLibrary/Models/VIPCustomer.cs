using PizzaLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class VIPCustomer : Customer
    {
        public int Discount{ get; set; }
        public VIPCustomer(string name, string mobile, string address, int discount) : base(name, mobile, address)
        {
            //if (Discount > 25)
            //{
            //    throw new TooHighDiscountException($"Rabatten på {discount}% er for høj, maksimal discount er 25%");
            //}
            Discount = discount;
           
        }

        public override string ToString()
        {
            return base.ToString() + $" Kundetype: VIP med: {Discount}% rabat";
        }
    }
}
