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
    public class HttpGroupDetailsRequestService : HttpRequestService<GroupDetailsViewModel>
    {
        /// <summary>
        /// Get response from server if GroupDetail with given ids exists.
        /// </summary>
        /// <param name="groupId">Id of a group.</param>
        /// <param name="userId">Id of a user</param>
        /// <returns>true if such detail exists, false otherwise</returns>
        public async Task<bool> DetailExists(int groupId, int userId )
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl + "DetailExists/" + groupId + "/"+userId);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    bool responseObject = await response.Content.ReadAsAsync<bool>();
                    return responseObject;
                }
                else
                {
                    return false;
                }
            }
        }
        public async Task<GroupDetailsViewModel> RemoveDetail(int groupId, int userId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl + "RemoveDetail/" + groupId + "/" + userId);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    GroupDetailsViewModel responseObject = await response.Content.ReadAsAsync<GroupDetailsViewModel>();
                    return responseObject;
                }
                else
                {
                    return default(GroupDetailsViewModel);
                }
            }
        }
    }
}
