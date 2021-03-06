﻿using System;
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
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url + "DetailExists/" + groupId + "/" + userId);
                if (response.IsSuccessStatusCode)
                {
                    var responseObject = await response.Content.ReadAsAsync<bool>();
                    
                    return responseObject;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Sends request to the api to delete GroupsDetail with given ids.
        /// </summary>
        /// <param name="groupId">id of the group.</param>
        /// <param name="userId">id of the user</param>
        /// <returns>Deleted detail view model, default value</returns>
        public async Task<GroupDetailsViewModel> RemoveDetail(int groupId, int userId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url + "RemoveDetail/" + groupId + "/" + userId);
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
        /// <summary>
        /// All details of groups that user belongs to.
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>List of details, default value</returns>
        public async Task<ICollection<GroupDetailsViewModel>> GetGroupDetailsForUser(int userId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url + "GetGroupDetailsForUser/" + userId);
                if (response.IsSuccessStatusCode)
                {
                    var responseObject = await response.Content.ReadAsAsync<List<GroupDetailsViewModel>>();
                    return responseObject;
                }
                else
                {
                    return default(List<GroupDetailsViewModel>);
                }
            }
        }
        /// <summary>
        /// All details of the group.
        /// </summary>
        /// <param name="groupId">group id</param>
        /// <returns>List of details, default value</returns>
        public async Task<ICollection<GroupDetailsViewModel>> GetGroupDetailsForGroup(int groupId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url + "GetGroupDetailsForGroup/" + groupId);
                if (response.IsSuccessStatusCode)
                {
                    var responseObject = await response.Content.ReadAsAsync<List<GroupDetailsViewModel>>();
                    return responseObject;
                }
                else
                {
                    return default(List<GroupDetailsViewModel>);
                }
            }
        }
    }
}
