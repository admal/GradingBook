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
    class HttpUserRequestService : HttpRequestService<Users>
    {
        public HttpUserRequestService() : base()
        {
            
        }
        public async Task<Users> GetUserByUsername(string username)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url + "GetByUsername/" + username);
                if (response.IsSuccessStatusCode)
                {
                    Users responseUsers = await response.Content.ReadAsAsync<Users>();
                    return responseUsers;
                }
                return null;
            }
        }
    }
}
