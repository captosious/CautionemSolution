using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Cautionem.Models;
using Microsoft.EntityFrameworkCore;

namespace Cautionem.Data
{
    public class CustomerContactService
    {
        private readonly MyAppSettings myAppSettings;
        private readonly CautionemContext cautionemContext;

        public CustomerContactService(MyAppSettings appSettings, CautionemContext cautionemContext)
        {
            this.myAppSettings = appSettings;
            this.cautionemContext = cautionemContext;
        }

        public async Task<IEnumerable<CustomerContact>> GetAll(Customer customer)
        {
            try
            {
                return await Task.FromResult((IEnumerable<CustomerContact>)cautionemContext.CustomerContacts.AsEnumerable().Where(x => x.CompanyId == customer.CompanyId && x.CustomerId==customer.CustomerId));
            }
            catch
            {
                return null;
            }
        }

        public async Task Add(CustomerContact customerContact)
        {
            await cautionemContext.AddAsync(customerContact);
            await cautionemContext.SaveChangesAsync();
        }

        public async Task Save(CustomerContact customerContact)
        {
            cautionemContext.Entry(customerContact).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await cautionemContext.SaveChangesAsync();
        }

        public void Detach(CustomerContact customerContact)
        {
            cautionemContext.Entry(customerContact).CurrentValues.SetValues(cautionemContext.Entry(customerContact).OriginalValues);
        }

        public void Delete(CustomerContact customerContact)
        {
            CustomerContact cuTemp = new CustomerContact();

            cuTemp = cautionemContext.CustomerContacts.First(x => x.CompanyId == customerContact.CompanyId && x.CustomerId == customerContact.CustomerId && x.Id == customerContact.Id);
            cautionemContext.CustomerContacts.Remove(cuTemp);
            cautionemContext.SaveChanges();
        }
    }
}