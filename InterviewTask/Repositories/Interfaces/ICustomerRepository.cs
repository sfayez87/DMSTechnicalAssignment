using InterviewTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
    }
}
