using System;
using System.Threading.Tasks;
using GradingBookProject.Http;
using GradingBookProject.ViewModels;
using GradingBookProject.Validation;
using System.Collections.Generic;

namespace GradingBookProject.Data
{
    public class HttpUsersRepository : HttpRepository<UsersViewModel, HttpUserRequestService>
    {
        /// <summary>
        /// Login user with provided data. Method sends request to server and checks data corectness.
        /// </summary>
        /// <param name="username">username of user</param>
        /// <param name="passwd">password of user</param>
        /// <returns>true - if login process was succesful, false - otherwise</returns>
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
        /// <summary>
        /// Get single user with the given username.
        /// </summary>
        /// <param name="username">username of user</param>
        /// <returns>user</returns>
        public async Task<UsersViewModel> GetUser(string username)
        {
            var user = await requestService.GetUserByUsername(username);
            return user;
        }
        /// <summary>
        /// Checks if user with given username exists
        /// </summary>
        /// <param name="username">username of user</param>
        /// <returns>true - if it exists, false -otherwise</returns>
        public async Task<bool> UserExists(string username)
        {
            var user = await requestService.GetUserByUsername(username);
            return user != null;
        }
        /// <summary>
        /// Gets Users belonging to given group.
        /// </summary>
        /// <param name="groupId">Id of a group we want users from.</param>
        /// <returns>Collection of users view models.</returns>
        public async Task<ICollection<UsersViewModel>> GetUsersOfGroup(int groupId) 
        {
            var users = await requestService.GetUsersByGroupId(groupId);
            if (users == null)
                return null;

            return users;
        }
    }
}
