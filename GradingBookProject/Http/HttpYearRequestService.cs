using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GradingBookProject.Models;

namespace GradingBookProject.Http
{
    class HttpYearRequestService : HttpRequestService<Years>
    {
        public HttpYearRequestService() : base()
        {

        }
        /// <summary>
        /// Find year by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>List of years of given username, null if there is no such a user.</returns>
        public async Task<IQueryable<Years>> GetYearsByUsername(string username)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url + "GetByUsername/" + username);

                if (response.IsSuccessStatusCode)
                {
                    IQueryable<Years> responseYears = await response.Content.ReadAsAsync<IQueryable<Years>>();
                    return responseYears;
                }
                return null;
            }
        }
    }
}
