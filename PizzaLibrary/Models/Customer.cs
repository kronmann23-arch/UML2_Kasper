using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class Customer : ICustomer
    {
        private int _id;
        private static int _counter=0;
        public string Address { get ; set; }
        public bool ClubMember { get ; set ; }

        public int Id 
        {
            get { return _id; }
           
        }

        
        public string Mobile { get ; set ; }
        public string Name { get ; set; }
        public Customer(string name,string mobile,string address)
        {
            Name=name;
            Mobile=mobile;
            Address=address;
            _id = _counter++;
            
        }

        public override string ToString()
        {
            return $"Name: {Name} Mobile: {Mobile} Address: {Address} Customer Number:{_id}";
        }

    }

    
}
