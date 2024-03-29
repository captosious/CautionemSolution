﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Cautionem.Models;
using Microsoft.EntityFrameworkCore;

namespace Cautionem.Data
{
    public class CustomerService
    {
        private readonly MyAppSettings myAppSettings;
        private readonly CautionemContext cautionemContext;

        public CustomerService(MyAppSettings appSettings, CautionemContext cautionemContext)
        {
            this.myAppSettings = appSettings;
            this.cautionemContext = cautionemContext;
        }

        public async Task<IEnumerable<Customer>> GetAll(int intCompanyID)
        {
            try {
                return await Task.FromResult((IEnumerable<Customer>)cautionemContext.Customers.AsEnumerable().Where(x => x.CompanyId == intCompanyID));
            }
            catch {
                return null;
            }
        }

        public async Task<Customer> Get(int companyId)
        {
            return await Task.FromResult((Customer)cautionemContext.Customers.FirstOrDefault(x => x.CompanyId == companyId));
        }

        public async Task Add(Customer customer)
        {
            await cautionemContext.AddAsync(customer);
            await cautionemContext.SaveChangesAsync();
        }

        public async Task Save(Customer customer)
        {
            cautionemContext.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await cautionemContext.SaveChangesAsync();
        }

        public void Detach(Customer customer)
        {
            cautionemContext.Entry(customer).CurrentValues.SetValues(cautionemContext.Entry(customer).OriginalValues);
        }

    }
}