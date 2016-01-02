﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradingBookProject.Http;
using GradingBookProject.ViewModels;
using GradingBookProject.Validation;

namespace GradingBookProject.Data
{
    class HttpUsersRepository : HttpRepository<UsersViewModel, HttpUserRequestService>
    {
        public async Task<bool> LoginUser(string username, string passwd)
        {
            UsersViewModel user = null;
            try
            {
                user = await GetUser(username);
                
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show("Unknnown error occured!");
            }

            if (user != null)
            {
                var en = new DataEncryptor();
                var encryptedPasswd = en.GetSha256String(passwd);
                if (user.passwd == encryptedPasswd)
                {
                    Globals.CurrentUser = user;
                    return true;
                }
            }
            return false;
        }

        public async Task<UsersViewModel> GetUser(string username)
        {
            var user = await requestService.GetUserByUsername(username);
            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            var user = await requestService.GetUserByUsername(username);
            return user != null;
        }
    }
}
