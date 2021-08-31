using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Cautionem.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Cautionem.Data
{
    public class CountryService
    {
        private readonly MyAppSettings myAppSettings;
        private readonly CautionemContext cautionemContext;

        public CountryService(MyAppSettings appSettings, CautionemContext cautionemContext)
        {
            this.myAppSettings = appSettings;
            this.cautionemContext = cautionemContext;
        }

        public async Task<IEnumerable<Country>> GetAll(int companyId)
        {
            return await Task.FromResult((IEnumerable<Country>)cautionemContext.Banks.Where(x => x.CompanyId == companyId));
        }

        public async Task<Bank> Get(int companyId)
        {
            return await Task.FromResult((Bank)cautionemContext.Banks.FirstOrDefault(x => x.CompanyId == companyId));
        }

        public async Task Add(Bank bank)
        {
            await cautionemContext.AddAsync(bank);
            await cautionemContext.SaveChangesAsync();
        }

        public async Task Save(Bank bank)
        {
            cautionemContext.Entry(bank).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //cautionemContext.Bank.Update(bank);
            //if (cautionemContext.ModelState.IsValid)
            //{
            await cautionemContext.SaveChangesAsync();

            //}
        }

        public void Detach(Bank bank)
        {
            cautionemContext.Entry(bank).CurrentValues.SetValues(cautionemContext.Entry(bank).OriginalValues);
        }

        // Extra

        public static bool ValidateBankAccount(string bankAccount)
        {
            bankAccount = bankAccount.ToUpper(); //IN ORDER TO COPE WITH THE REGEX BELOW
            if (String.IsNullOrEmpty(bankAccount))
                return false;
            else if (System.Text.RegularExpressions.Regex.IsMatch(bankAccount, "^[A-Z0-9]"))
            {
                bankAccount = bankAccount.Replace(" ", String.Empty);
                string bank =
                bankAccount.Substring(4, bankAccount.Length - 4) + bankAccount.Substring(0, 4);
                int asciiShift = 55;
                StringBuilder sb = new StringBuilder();
                foreach (char c in bank)
                {
                    int v;
                    if (Char.IsLetter(c)) v = c - asciiShift;
                    else v = int.Parse(c.ToString());
                    sb.Append(v);
                }
                string checkSumString = sb.ToString();
                int checksum = int.Parse(checkSumString.Substring(0, 1));
                for (int i = 1; i < checkSumString.Length; i++)
                {
                    int v = int.Parse(checkSumString.Substring(i, 1));
                    checksum *= 10;
                    checksum += v;
                    checksum %= 97;
                }
                return checksum == 1;
            }
            else
                return false;
        }
    }
}