using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GradingBookProject.Models;
using GradingBookProject.ViewModels;

namespace GradingBookProject.Http
{
    class HttpYearRequestService : HttpRequestService<YearsViewModel>
    {
        public HttpYearRequestService() : base()
        {

        }
        /// <summary>
        /// Find year by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>List of years of given username, null if there is no such a user.</returns>
        public async Task<ICollection<YearsViewModel>> GetYearsByUsername(string username)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url + "GetByUsername/" + username);

                if (response.IsSuccessStatusCode)
                {
                    ICollection<YearsViewModel> responseYears = await response.Content.ReadAsAsync<ICollection<YearsViewModel>>();
                    return responseYears;
                }
                return null;
            }
        }
    }
}
