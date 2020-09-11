using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Cautionem.Models;

namespace Cautionem.Data
{
    public class PaymentTypeService
    {
        private readonly MyAppSettings myAppSettings;
        private readonly CautionemContext cautionemContext;

        public PaymentTypeService(MyAppSettings appSettings, CautionemContext cautionemContext)
        {
            this.myAppSettings = appSettings;
            this.cautionemContext = cautionemContext;
        }

        public async Task<IEnumerable<PaymentType>> GetAll(int companyId)
        {
            return await Task.FromResult((IEnumerable<PaymentType>)cautionemContext.PaymentType.Where(x => x.CompanyId == companyId));
        }

        public async Task<PaymentType> Get(int companyId)
        {
            return await Task.FromResult((PaymentType)cautionemContext.PaymentType.FirstOrDefault(x => x.CompanyId == companyId));
        }

        public async Task Add(PaymentType paymentType)
        {
            await cautionemContext.AddAsync(paymentType);
            await cautionemContext.SaveChangesAsync();
        }

        public async Task Save(PaymentType paymentType)
        {
            cautionemContext.PaymentType.Update(paymentType);
            await cautionemContext.SaveChangesAsync();
        }

        public void Detach(PaymentType paymentType)
        {
            cautionemContext.Entry(paymentType).CurrentValues.SetValues(cautionemContext.Entry(paymentType).OriginalValues);
        }
    }
}