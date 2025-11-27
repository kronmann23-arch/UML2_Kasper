using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class CompanyInfo
    {
       public int Vat { get; set; }
       public string Cvr { get; set; }

       public string Name { get; set; }
       public bool ClubDiscount { get; set; }

       private static CompanyInfo _instance = null;
       public static CompanyInfo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CompanyInfo();
                }
                return _instance;
            }
        }

       private CompanyInfo()//Måden man implemetnere en singleton er ved at gøre constructoren private
        {
            
        }
    }
}
