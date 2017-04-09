﻿using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.DAL.Interfaces
{
    interface ICustomerRepo
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int customerId);

        // bools for inserts, deletes, and updates so we can see if they worked
        void InsertCustomer(Customer customer);
        void DeleteCustomer(int customerId);
        void UpdateCustomer(Customer customer);
    }
}
