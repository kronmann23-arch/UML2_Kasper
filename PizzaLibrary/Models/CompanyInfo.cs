using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class CompanyInfo
    {
       public string Vat { get; set; }
       public string Cvr { get; set; }

       public string Name { get; set; }
       public double ClubDiscount { get; set; }
    }
}
