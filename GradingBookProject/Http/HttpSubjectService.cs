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
    class HttpSubjectRequestService : HttpRequestService<Years>
    {
        public HttpSubjectRequestService()
            : base()
        {

        }
        /// <summary>
        /// Find all Subjects for a given Year.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>List of subjects of a given Year, null if there is no such a Year.</returns>
        public async Task<IQueryable<Subjects>> GetSubjectsOfYear(Years year)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url + "GetByYearId/" + year.id);

                if (response.IsSuccessStatusCode)
                {
                    IQueryable<Subjects> responseSubjects = await response.Content.ReadAsAsync<IQueryable<Subjects>>();
                    return responseSubjects;
                }
                return null;
            }
        }
    }
}
