using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cautionem.Models;

namespace Cautionem.Data
{
    public class CompanyService
    {
        private readonly MyAppSettings myAppSettings;
        private readonly CautionemContext cautionemContext;

        public CompanyService(MyAppSettings appSettings, CautionemContext cautionemContext)
        {
            this.myAppSettings = appSettings;
            this.cautionemContext = cautionemContext;
        }

        public async Task<Company> Get(int companyId)
        {
            return await Task.FromResult ((Company)cautionemContext.Company.FirstOrDefault(x => x.CompanyId == companyId));
        }
    }
}