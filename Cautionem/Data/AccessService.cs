using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components.Authorization;
using Cautionem.Models;
using System.Linq;

namespace Cautionem.Data
{
    public class AccessService
    {
        private readonly MyAppSettings _appSettings;
        public Login MyLogin { get; set; }
        private AuthenticationStateProvider _AuthenStateProv;
        private readonly CautionemContext _cautionemContext;

        public AccessService(MyAppSettings appSettings, CautionemContext cautionemContext, AuthenticationStateProvider AuthenStateProv)
        {
            _appSettings = appSettings;
            _cautionemContext = cautionemContext;
            _AuthenStateProv = AuthenStateProv;
            MyLogin = new Login();
        }

        public async Task<int> LogInAsync(string Username, string Password)
        {
            MyLogin.CompanyId = 1;
            MyLogin.Username = Username;
            
            User user = new User();

            try
            {
                user = (User)_cautionemContext.Users.FirstOrDefault(x => x.CompanyId == MyLogin.CompanyId && x.Username == MyLogin.Username);

                if (user != null)
                {
                    if (user.Password == Password)
                    {
                        //Success Authenticated
                        MyLogin.Id = user.Id;
                        MyLogin.Name = user.Name;
                        MyLogin.FamilyName = user.FamilyName;
                        MyLogin.CompleteName = user.Name + " " + user.FamilyName;
                        MyLogin.CompleteNameReverse = user.FamilyName + ", " + user.Name;
                        MyLogin.SecurityId = user.SecurityId;
                        MyLogin.Picture = user.Picture;
                        ((CustomAuthenticationStateProvider)_AuthenStateProv).MarkUserAsAuthenticated(Username, MyLogin.SecurityId.ToString());
                        return 0;
                    }
                    else
                    {
                        //Wrong Password
                        await LogOut();
                        return 3;
                    }
                }
                else
                {
                    // If somethig went wrong... better to leave the user as logged off.
                    await LogOut();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                // If somethig went wrong... better to leave the user as logged off.
                await LogOut();
                return 2;
            }
        }
    
        public Task<int> LogOut()
        {
            ((CustomAuthenticationStateProvider)_AuthenStateProv).MarkUserAsNotAuthenticated();
            MyLogin = new Login();
            return Task.FromResult(0);
        }
    }
}
