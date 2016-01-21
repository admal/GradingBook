using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GradingBookProject.ViewModels;

namespace GradingBookProject.Http
{
    public class HttpUserRequestService : HttpRequestService<UsersViewModel>
    {
        public HttpUserRequestService() : base()
        {
            
        }
        /// <summary>
        /// Find user by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>User with given username, null if there is no such a user.</returns>
        public async Task<UsersViewModel> GetUserByUsername(string username)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url + "GetByUsername/" + username);

                if (response.IsSuccessStatusCode)
                {
                    var responseUsers = await response.Content.ReadAsAsync<UsersViewModel>();
                    return responseUsers;
                }
                return null;
            }
        }
        /// <summary>
        /// Find all users of given group
        /// </summary>
        /// <param name="groupId">Id of a group we want users from.</param>
        /// <returns>Collection of users belonging to the group.</returns>
        public async Task<ICollection<UsersViewModel>> GetUsersByGroupId(int groupId) 
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url + "GetByGroupId/" + groupId);

                if (response.IsSuccessStatusCode)
                {
                    var responseUsers = await response.Content.ReadAsAsync<ICollection<UsersViewModel>>();
                    return responseUsers;
                }
                return null;
            }
        }
    }
}
