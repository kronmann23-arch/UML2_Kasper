using PizzaLibrary.Data;
using PizzaLibrary.Exceptions;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private Dictionary<string, Customer> _customers;
        public int Count { get { return _customers.Count; } }

        public CustomerRepository()
        {
            //_customers = new Dictionary<string, Customer>();
            _customers = MockData.CustomerData;
        }
        public void AddCustomer(Customer customer)
        {
            ////foreach (Customer existingcustomer in _customers.Values)
            ////{
            //    if (existingcustomer.Mobile == customer.Mobile)
            //    {
            //        throw new CustomerMobileNumberExist($"Mobilnummeret {customer.Mobile} findes allerede i Kundekaroteket.");
            //    }


            //}
            if (_customers.ContainsKey(customer.Mobile))
            {
                throw new CustomerMobileNumberExist($"Mobilnummeret {customer.Mobile} findes allerede i Kundekaroteket.");
            }
            _customers.Add(customer.Mobile, customer);
        }
        public List<Customer> GetAll()
        {
            List<Customer> cReturnList = new List<Customer>();
            foreach (Customer c in _customers.Values)
            {
                cReturnList.Add(c);
            }
            return cReturnList;
            //return _customers.Values.ToList();
        }

        public Customer GetCustomerByMobile(string mobile)
        {
            if (_customers.ContainsKey(mobile))
            {
                return _customers[mobile];

            }
            return null;
        }

        public void PrintAllCustomers()
        {
            foreach (Customer c in _customers.Values)
            {
                Console.WriteLine(c);
            }
        }

        public void RemoveCustomer(string mobile)
        {
            _customers.Remove(mobile);
        }

        public List<Customer> GetAllClubMembers()
        {
            List<Customer> clubMembers = new List<Customer>();
            foreach(Customer customer in _customers.Values)
            {
                if (customer.ClubMember)
                {
                    clubMembers.Add(customer);
                }
               
            }
            return clubMembers;
        }
       
       public List<Customer> GetAllCustomersFromRoskilde()
        {
            List<Customer> roskildeC = new List<Customer>();
            foreach(Customer customer in _customers.Values)
            {
                if (customer.Address.Contains("Roskilde"))
                {
                    roskildeC.Add(customer);
                  
                }
            }
            return roskildeC;
        }

        

    }
}
