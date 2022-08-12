using InterviewTask.Models;
using InterviewTask.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTask.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private ApplicationDbContext context;
        public CustomerRepository()
        {
            context = new ApplicationDbContext();
        }
        /// <summary>
        /// This function add new customer
        /// </summary>
        /// <param name="customer"></param>
        public void AddCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }
    }
}