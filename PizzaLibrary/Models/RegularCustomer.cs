using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class RegularCustomer : Customer
    {
        public RegularCustomer(string name, string mobile, string address) : base(name, mobile, address)
        {

        }
        public override string ToString()
        {
            return base.ToString() + "Kundetype: Almindelig";
        }
    }
}
