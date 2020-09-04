using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Cautionem.Models;

namespace Cautionem.Data
{
    public class BankService
    {
        private readonly MyAppSettings myAppSettings;
        private readonly CautionemContext cautionemContext;

        public BankService(MyAppSettings appSettings, CautionemContext cautionemContext)
        {
            this.myAppSettings = appSettings;
            this.cautionemContext = cautionemContext;
        }

        public async Task<IEnumerable<Bank>> GetAll(int companyId)
        {
            return await Task.FromResult((IEnumerable<Bank>)cautionemContext.Bank.Where(x => x.CompanyId == companyId));
        }


        public async Task<Bank> Get(int companyId)
        {
            return await Task.FromResult((Bank)cautionemContext.Bank.FirstOrDefault(x => x.CompanyId == companyId));
        }

        public async Task Save(Bank bank)
        {
            cautionemContext.Bank.Update(bank);
            //if (cautionemContext.ModelState.IsValid)
            //{
            await cautionemContext.SaveChangesAsync();
            //}
        }


    }
}