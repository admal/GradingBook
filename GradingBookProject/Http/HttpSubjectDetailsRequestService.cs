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
    class HttpSubjectDetailsRequestService : HttpRequestService<SubjectDetails>
    {
        public HttpSubjectDetailsRequestService()
            : base()
        {

        }
        /// <summary>
        /// Find all Grades for a given Subject.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>List of Grades of a given Subject, null if there is no such a Subject.</returns>
        public async Task<IQueryable<SubjectDetails>> GetSubjectDetailsOfSubject(Subjects subject)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url + "GetBySubjectId/" + subject.id);

                if (response.IsSuccessStatusCode)
                {
                    IQueryable<SubjectDetails> responseSubjectDetails = await response.Content.ReadAsAsync<IQueryable<SubjectDetails>>();
                    return responseSubjectDetails;
                }
                return null;
            }
        }
    }
}
